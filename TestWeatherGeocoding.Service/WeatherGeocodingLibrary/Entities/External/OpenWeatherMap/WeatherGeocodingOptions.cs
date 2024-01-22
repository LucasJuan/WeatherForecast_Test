﻿namespace WeatherGeocoding.Domain.Entities.External.OpenWeatherMap;

public class WeatherGeocodingOptions
{
    public string ApiKey { get; set; }
    public string Benchmark {  get; set; }
    public string Vintage { get; set; }
    public string WeatherUrl { get; set; }
    public string GeoCodingUrl { get; set; }
}