namespace GeoLocation.Contracts.ExternalApiResponseDtos;

/// <summary>
///     Модель ответа внешнего Api.
/// </summary>
public class ExternalApiResponseDto
{
    /// <summary>
    ///     Широта.
    /// </summary>
    public double Lat { get; set; }

    /// <summary>
    ///     Долгота.
    /// </summary>
    public double Lon { get; set; }
}