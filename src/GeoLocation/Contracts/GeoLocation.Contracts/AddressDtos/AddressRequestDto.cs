namespace GeoLocation.Contracts.AddressDtos;

/// <summary>
///     Модель для запроса по адресу.
/// </summary>
public class AddressRequestDto
{
    /// <summary>
    ///     Страна.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    ///     Город.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    ///     Улица.
    /// </summary>
    public string? Street { get; set; }
}