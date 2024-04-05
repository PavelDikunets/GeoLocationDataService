using GeoLocation.Clients.ExternalApi.Nominatim.Exceptions;
using GeoLocation.Clients.ExternalApi.Nominatim.Services;
using GeoLocation.Contracts.AddressDtos;
using GeoLocation.Contracts.ErrorDtos;
using GeoLocation.Contracts.GeoLocationDtos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GeoLocation.Application.AppData.Contexts.GeoLocationData.Services;

/// <inheritdoc />
public class GeoLocationDataService : IGeoLocationDataService
{
    private readonly ILogger<GeoLocationDataService> _logger;
    private readonly IOpenStreetMapService _openStreetMapService;

    /// <summary>
    /// </summary>
    /// <param name="openStreetMapService"></param>
    /// <param name="logger"></param>
    public GeoLocationDataService(IOpenStreetMapService openStreetMapService, ILogger<GeoLocationDataService> logger)
    {
        _openStreetMapService = openStreetMapService;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<List<GeoLocationDto>?> GetGeoLocationByAddressAsync(AddressDto addressDto,
        CancellationToken cancellationToken)
    {
        var responseMessage =
            await _openStreetMapService.GetGeoLocationDataByAddressAsync(addressDto, cancellationToken);

        var content = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var errorDto = JsonConvert.DeserializeObject<ErrorWrapperDto>(content);

            _logger.LogInformation(
                "Запрос: '{Request}', Сообщение об ошибке: '{ErrorMessage}', Код состояния: '{StatusCode}'.",
                JsonConvert.SerializeObject(addressDto), errorDto.Error.Message, (int)responseMessage.StatusCode);

            throw new OpenStreetMapException(errorDto.Error.Message, responseMessage.StatusCode);
        }

        var geoData = JsonConvert.DeserializeObject<List<GeoLocationDto>>(content);

        return geoData;
    }
}