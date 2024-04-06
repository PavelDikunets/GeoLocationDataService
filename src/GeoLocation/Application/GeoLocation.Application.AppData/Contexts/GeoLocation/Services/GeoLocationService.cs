using Dadata;
using GeoLocation.Clients.ExternalApi.Nominatim.Exceptions;
using GeoLocation.Clients.ExternalApi.Nominatim.Services;
using GeoLocation.Contracts.AddressDtos;
using GeoLocation.Contracts.ErrorDtos;
using GeoLocation.Contracts.ExternalApiResponseDtos;
using GeoLocation.Contracts.GeoLocationDataDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GeoLocation.Application.AppData.Contexts.GeoLocation.Services;

/// <inheritdoc />
public class GeoLocationService : IGeoLocationService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<GeoLocationService> _logger;
    private readonly IOpenStreetMapService _openStreetMapService;

    /// <summary>
    ///     Инициализирует экземпляр <see cref="GeoLocationService" />.
    /// </summary>
    /// <param name="openStreetMapService">Сервис для работы с внешним API OpenStreetMap.</param>
    /// <param name="logger">Логгер.</param>
    /// <param name="configuration">Конфигурация.</param>
    public GeoLocationService(IOpenStreetMapService openStreetMapService, ILogger<GeoLocationService> logger,
        IConfiguration configuration)
    {
        _openStreetMapService = openStreetMapService;
        _logger = logger;
        _configuration = configuration;
    }

    /// <inheritdoc />
    public async Task<List<GeoLocationDataDto>> GetGeoLocationByAddressAsync(AddressRequestDto addressRequestDto,
        CancellationToken cancellationToken)
    {
        var responseMessage =
            await _openStreetMapService.GetGeoLocationDataByAddressAsync(addressRequestDto, cancellationToken);

        var content = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var errorDto = JsonConvert.DeserializeObject<ErrorWrapperDto>(content);

            _logger.LogInformation(
                "Запрос: '{Request}', Сообщение об ошибке: '{ErrorMessage}', Код состояния: '{StatusCode}'.",
                JsonConvert.SerializeObject(addressRequestDto), errorDto.Error.Message,
                (int)responseMessage.StatusCode);

            throw new OpenStreetMapException(errorDto.Error.Message, responseMessage.StatusCode);
        }

        var externalApiResponse = JsonConvert.DeserializeObject<List<ExternalApiResponseDto>>(content);

        var geoLocationDataList = externalApiResponse.Select(apiResponse => new GeoLocationDataDto
        {
            Latitude = apiResponse.Lat,
            Longitude = apiResponse.Lon
        }).ToList();

        _logger.LogInformation("Геоданные успешно получены: {GeoLocationData}",
            JsonConvert.SerializeObject(geoLocationDataList));

        return geoLocationDataList;
    }

    /// <inheritdoc />
    public async Task<List<AddressDto>> GetAddressesByGeoLocationDataAsync(GeoLocationDataDto geoLocationDataDto,
        CancellationToken cancellationToken)
    {
        var token = GetDadataApiToken();

        var api = new SuggestClientAsync(token);

        var externalApiResponse = await api.Geolocate(geoLocationDataDto.Latitude, geoLocationDataDto.Longitude,
            count: 10, cancellationToken: cancellationToken);

        var addressesList = externalApiResponse.suggestions.Select(s => new AddressDto
        {
            Region = s.data.region,
            City = s.data.city,
            Street = s.data.street,
            House = s.data.house,
            Flat = s.data.flat
        }).ToList();

        _logger.LogInformation("Ближайшие адреса успешно получены: {Adresses}",
            JsonConvert.SerializeObject(addressesList));

        return addressesList;
    }

    private string GetDadataApiToken()
    {
        var token = _configuration["DadataApiToken"];

        if (token != null) return token;

        _logger.LogError("DadataApiToken не найден в конфигурации.");
        throw new InvalidOperationException("DadataApiToken не найден в конфигурации.");
    }
}