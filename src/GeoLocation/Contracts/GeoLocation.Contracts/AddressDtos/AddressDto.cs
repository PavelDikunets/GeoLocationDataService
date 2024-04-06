namespace GeoLocation.Contracts.AddressDtos;

/// <summary>
///     Модель адреса.
/// </summary>
public class AddressDto
{
    /// <summary>
    ///     Регион.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    ///     Город.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///     Улица.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    ///     Дом.
    /// </summary>
    public string House { get; set; }

    /// <summary>
    ///     Квартира.
    /// </summary>
    public string Flat { get; set; }
}