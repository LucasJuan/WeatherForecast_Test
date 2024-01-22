using WeatherGeocoding.Domain.Entities.External.OpenWeatherMap;
namespace WeatherGeocoding.Domain.Entities.External.NationalWeatherService;
public class WeatherForecastResult : ErrorResponse
{
    public WeatherForecastResult() { }

    public WeatherForecastResult(string errorMessage) : base(errorMessage) { }
    public string[] Context { get; set; }
    public Dictionary<string, object> Properties { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public List<List<List<double>>> Coordinates { get; set; }
}

public class Elevation
{
    public string UnitCode { get; set; }
    public double Value { get; set; }
}

public class Temperature
{
    public string Uom { get; set; }
    public List<TemperatureValue> Values { get; set; }
}

public class TemperatureValue
{
    public string ValidTime { get; set; }
    public double Value { get; set; }
}

public class Hazard
{
    public string ValidTime { get; set; }
    public List<HazardValue> Value { get; set; }
}

public class HazardValue
{
    public string Phenomenon { get; set; }
    public string Significance { get; set; }
    public int EventNumber { get; set; }
}

public class WeatherObject
{
    public string Id { get; set; }
    public string Type { get; set; }
    public Geometry Geometry { get; set; }
    public Dictionary<string, object> Properties { get; set; }
}

public class Weather
{
    public List<WeatherValue> Values { get; set; }
}

public class WeatherValue
{
    public string ValidTime { get; set; }
    public List<WeatherDetail> Value { get; set; }
}

public class WeatherDetail
{
    public object Coverage { get; set; }
    public object Weather { get; set; }
    public object Intensity { get; set; }
    public Visibility Visibility { get; set; }
    public List<object> Attributes { get; set; }
}

public class Visibility
{
    public string UnitCode { get; set; }
    public object Value { get; set; }
}

public class ProbabilityOfPrecipitation
{
    public string Uom { get; set; }
    public List<ProbabilityOfPrecipitationValue> Values { get; set; }
}

public class ProbabilityOfPrecipitationValue
{
    public string ValidTime { get; set; }
    public int Value { get; set; }
}

public class QuantitativePrecipitation
{
    public string Uom { get; set; }
    public List<QuantitativePrecipitationValue> Values { get; set; }
}

public class QuantitativePrecipitationValue
{
    public string ValidTime { get; set; }
    public double Value { get; set; }
}

public class WeatherData
{
    public string ValidTime { get; set; }
    public List<WeatherDetail> Value { get; set; }
}

public class WeatherDetailWithValues
{
    public string Uom { get; set; }
    public List<WeatherData> Values { get; set; }
}

public class Gridpoint
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string UpdateTime { get; set; }
    public string ValidTimes { get; set; }
    public Elevation Elevation { get; set; }
    public string ForecastOffice { get; set; }
    public string GridId { get; set; }
    public string GridX { get; set; }
    public string GridY { get; set; }
    public Temperature Temperature { get; set; }
    public Temperature Dewpoint { get; set; }
    public Temperature MaxTemperature { get; set; }
    public Temperature MinTemperature { get; set; }
    public WeatherDetailWithValues RelativeHumidity { get; set; }
    public WeatherDetailWithValues ApparentTemperature { get; set; }
    public WeatherDetailWithValues WetBulbGlobeTemperature { get; set; }
    public WeatherDetailWithValues HeatIndex { get; set; }
    public Temperature WindChill { get; set; }
    public WeatherDetailWithValues SkyCover { get; set; }
    public WeatherDetailWithValues WindDirection { get; set; }
    public WeatherDetailWithValues WindSpeed { get; set; }
    public WeatherDetailWithValues WindGust { get; set; }
    public Weather Weather { get; set; }
    public List<Hazard> Hazards { get; set; }
    public ProbabilityOfPrecipitation ProbabilityOfPrecipitation { get; set; }
    public QuantitativePrecipitation QuantitativePrecipitation { get; set; }
    public QuantitativePrecipitation IceAccumulation { get; set; }
    public QuantitativePrecipitation SnowfallAmount { get; set; }
    public List<object> SnowLevel { get; set; }
    public WeatherDetailWithValues CeilingHeight { get; set; }
    public WeatherDetailWithValues Visibility { get; set; }
    public WeatherDetailWithValues TransportWindSpeed { get; set; }
    public WeatherDetailWithValues TransportWindDirection { get; set; }
    public WeatherDetailWithValues MixingHeight { get; set; }
    public WeatherDetailWithValues HainesIndex { get; set; }
    public WeatherDetailWithValues LightningActivityLevel { get; set; }
    public List<object> TwentyFootWindSpeed { get; set; }
    public List<object> TwentyFootWindDirection { get; set; }
    public List<object> WaveHeight { get; set; }
    public List<object> WavePeriod { get; set; }
    public List<object> WaveDirection { get; set; }
    public List<object> PrimarySwellHeight { get; set; }
    public List<object> PrimarySwellDirection { get; set; }
    public List<object> SecondarySwellHeight { get; set; }
    public List<object> SecondarySwellDirection { get; set; }
    public List<object> WavePeriod2 { get; set; }
    public List<object> WindWaveHeight { get; set; }
    public List<object> DispersionIndex { get; set; }
    public List<object> Pressure { get; set; }
    public List<object> ProbabilityOfTropicalStormWinds { get; set; }
    public List<object> ProbabilityOfHurricaneWinds { get; set; }
    public List<object> PotentialOf15mphWinds { get; set; }
    public List<object> PotentialOf25mphWinds { get; set; }
    public List<object> PotentialOf35mphWinds { get; set; }
    public List<object> PotentialOf45mphWinds { get; set; }
    public List<object> PotentialOf20mphWindGusts { get; set; }
    public List<object> PotentialOf30mphWindGusts { get; set; }
    public List<object> PotentialOf40mphWindGusts { get; set; }
    public List<object> PotentialOf50mphWindGusts { get; set; }
    public List<object> PotentialOf60mphWindGusts { get; set; }
    public WeatherDetailWithValues GrasslandFireDangerIndex { get; set; }
    public WeatherDetailWithValues ProbabilityOfThunder { get; set; }
    public List<object> DavisStabilityIndex { get; set; }
    public List<object> AtmosphericDispersionIndex { get; set; }
    public List<object> LowVisibilityOccurrenceRiskIndex { get; set; }
    public List<object> Stability { get; set; }
    public WeatherDetailWithValues RedFlagThreatIndex { get; set; }
}

