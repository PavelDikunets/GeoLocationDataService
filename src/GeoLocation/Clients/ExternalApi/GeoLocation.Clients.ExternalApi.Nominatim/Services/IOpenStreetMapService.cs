using GeoLocation.Contracts.AddressDtos;

namespace GeoLocation.Clients.ExternalApi.Nominatim.Services;

/// <summary>
///     Сервис для работы с внешним API OpenStreetMap.
///     https://nominatim.openstreetmap.org/.
/// </summary>
public interface IOpenStreetMapService
{
    /// <summary>
    ///     Получить геоданные по адресу.
    /// </summary>
    /// <param name="address">Адрес.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Геоданные.</returns>
    Task<HttpResponseMessage> GetGeoLocationDataByAddressAsync(AddressDto address, CancellationToken cancellationToken);
}