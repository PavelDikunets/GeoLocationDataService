using GeoLocation.Contracts.AddressDtos;
using GeoLocation.Contracts.GeoLocationDataDtos;

namespace GeoLocation.Application.AppData.Contexts.GeoLocation.Services;

/// <summary>
///     Сервис для работы с геоданными.
/// </summary>
public interface IGeoLocationService
{
    /// <summary>
    ///     Получить геоданные по адресу.
    /// </summary>
    /// <param name="addressRequestDto">Модель адреса.</param>
    /// <param name="cancellationToken">Токен отмены операци.</param>
    /// <returns>Список геоданных.</returns>
    Task<List<GeoLocationDataDto>> GetGeoLocationByAddressAsync(AddressRequestDto addressRequestDto,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получить список ближайших адресов по геоданным.
    /// </summary>
    /// <param name="geoLocationDataDto">Модель с геоданными.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список адресов.</returns>
    Task<List<AddressDto>> GetAddressesByGeoLocationDataAsync(GeoLocationDataDto geoLocationDataDto,
        CancellationToken cancellationToken);
}