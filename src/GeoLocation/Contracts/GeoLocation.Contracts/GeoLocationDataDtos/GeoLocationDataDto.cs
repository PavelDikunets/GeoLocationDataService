using System.ComponentModel.DataAnnotations;

namespace GeoLocation.Contracts.GeoLocationDataDtos;

/// <summary>
///     Модель геоданных.
/// </summary>
public class GeoLocationDataDto
{
    /// <summary>
    ///     Широта.
    /// </summary>
    [Required]
    public double Latitude { get; set; }

    /// <summary>
    ///     Долгота.
    /// </summary>
    [Required]
    public double Longitude { get; set; }
}