using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherGeocoding.Domain.Entities.External.NationalWeatherService;
using WeatherGeocoding.Domain.Entities.External.OpenWeatherMap;
using WeatherGeocoding.Domain.Interface.External.OpenWeatherMap;

namespace WeatherGeocoding.Domain.Services.External.OpenWeatherMap;

public class OpenWeatherMapService : IOpenWeatherMapService
{
    private readonly IOptions<WeatherGeocodingOptions> _options;
    private readonly HttpClient _httpClient;

    public OpenWeatherMapService(IOptions<WeatherGeocodingOptions> options, HttpClient customHttpClient)
    {
        _options = options;
        _httpClient = customHttpClient;
    }

    /// <summary>
    /// Gets the weather forecast based on the provided address.
    /// </summary>
    /// <param name="address">The address for which to retrieve the weather forecast.</param>
    /// <returns>The weather forecast result.</returns>
    public async Task<WeatherForecastResult> GetWeatherForecastAsync(string address)
    {

        var geoCodeResult = await GeocodeAddressAsync(address, _options.Value.Benchmark, _options.Value.Vintage);

        if (!string.IsNullOrEmpty(geoCodeResult.ErrorMessage))
            return new WeatherForecastResult(geoCodeResult.ErrorMessage);

        if (geoCodeResult is not null)
        {
            var longitude = geoCodeResult?.Result.AddressMatches.Select(x => x.Coordinates.X).FirstOrDefault();
            var latitude = geoCodeResult?.Result.AddressMatches.Select(y => y.Coordinates.Y).FirstOrDefault();

            string url = $"{_options.Value.WeatherUrl}{latitude},{longitude}";

            try
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "MyAppService");

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    var jsonSerializerOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };

                    var result = JsonSerializer.Deserialize<GeoJsonLDContext>(await response.Content.ReadAsStringAsync(), jsonSerializerOptions);

                    if (result is null)
                        return new WeatherForecastResult($"Error to Deserialize Response API US National Weather Service");

                    if (result.Properties.ForecastGridData is not null)
                    {
                        var dataGrid = await _httpClient.GetAsync(result.Properties.ForecastGridData);

                        if (dataGrid.IsSuccessStatusCode)
                        {
                            string dataGridContent = await dataGrid.Content.ReadAsStringAsync();
                            var dataGridResult = JsonSerializer.Deserialize<WeatherForecastResult>(dataGridContent, jsonSerializerOptions);
                            return dataGridResult is not null ? dataGridResult
                                         : new WeatherForecastResult($"Error to Deserialize DataGrid Response API provided by US National Weather Service");

                        }
                        else
                            return new WeatherForecastResult($"Error to Call DataGrid API provided by US National Weather Service: {(int)dataGrid.StatusCode} - {dataGrid.ReasonPhrase}");

                    }
                    else
                        return new WeatherForecastResult($"Error to Call DataGrid API provided by US National Weather Service");
                }
                else
                {
                    return new WeatherForecastResult($"Error to call API OpenWeatherMap: {(int)response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                return new WeatherForecastResult($"Error to call API OpenWeatherMap: {ex.Message}");
            }
        }
        else
        {
            return new WeatherForecastResult($"Address not found");
        }
    }

    /// <summary>
    /// Obtain location information based on address.
    /// </summary>
    /// <param name="address">The address to geocode.</param>
    /// <param name="benchmark">The benchmark for geocoding.</param>
    /// <param name="vintage">The vintage for geocoding.</param>
    /// <returns>The geocoding result.</returns>
    public async Task<GeocodingResult> GeocodeAddressAsync(string address, string benchmark, string vintage)
    {
        string apiUrl = $"{_options.Value.GeoCodingUrl}address={Uri.EscapeDataString(address)}&benchmark={benchmark}&vintage={vintage}&format=json&";

        try
        {
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var result = JsonSerializer.Deserialize<GeocodingResult>(await response.Content.ReadAsStringAsync(), jsonSerializerOptions);

                return result is not null ? (result.Result.AddressMatches.Count <= 0 ? new GeocodingResult($"No results found for the specified address") : result)
                                          : new GeocodingResult($"Error to Deserialize Response API Geocoding");
            }
            else
            {
                return new GeocodingResult($"Error to call API Geocoding: {(int)response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            return new GeocodingResult($"Error to call API Geocoding: {ex.Message}");
        }
    }
}