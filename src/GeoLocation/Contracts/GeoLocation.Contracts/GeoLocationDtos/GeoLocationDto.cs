using Newtonsoft.Json;

namespace GeoLocation.Contracts.GeoLocationDtos;

/// <summary>
///     Модель геолокации.
/// </summary>
public class GeoLocationDto
{
    /// <summary>
    ///     Широта.
    /// </summary>
    [JsonProperty("lat")]
    public double Latitude { get; set; }

    /// <summary>
    ///     Долгота.
    /// </summary>
    [JsonProperty("lon")]
    public double Longitude { get; set; }
}