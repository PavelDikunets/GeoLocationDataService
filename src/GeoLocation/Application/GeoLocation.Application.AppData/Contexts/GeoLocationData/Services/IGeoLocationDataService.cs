using GeoLocation.Contracts.AddressDtos;
using GeoLocation.Contracts.GeoLocationDtos;

namespace GeoLocation.Application.AppData.Contexts.GeoLocationData.Services;

/// <summary>
///     Сервис для работы с геоданными.
/// </summary>
public interface IGeoLocationDataService
{
    /// <summary>
    /// Получить геоданные по адресу.
    /// </summary>
    /// <param name="addressDto">Модель адреса.</param>
    /// <param name="cancellationToken">Токен отмены операци.</param>
    /// <returns>Геоданные (широта, долгота).</returns>
    Task<List<GeoLocationDto>?> GetGeoLocationByAddressAsync(AddressDto addressDto, CancellationToken cancellationToken);
}