using GeoLocation.Application.AppData.Contexts.GeoLocationData.Services;
using GeoLocation.Contracts.AddressDtos;
using GeoLocation.Contracts.ErrorDtos;
using GeoLocation.Contracts.GeoLocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeoLocation.Host.Api.Controllers;

/// <summary>
/// Контроллер для работы с геоданными.
/// </summary>
[ApiController]
[Route("geolocation")]
public class GeoLocationDataController : ControllerBase
{
    private readonly IGeoLocationDataService _geoLocationDataService;
    private readonly ILogger<GeoLocationDataController> _logger;

    /// <summary>
    ///     Инициализирует экземпляр <see cref="GeoLocationDataController" />.
    /// </summary>
    /// <param name="logger">Логгер.</param>
    /// <param name="geoLocationDataService">Сервис для работы с геоданными.</param>
    public GeoLocationDataController(ILogger<GeoLocationDataController> logger,
        IGeoLocationDataService geoLocationDataService)
    {
        _logger = logger;
        _geoLocationDataService = geoLocationDataService;
    }

    /// <summary>
    ///     Получить геолокацию по адресу.
    /// </summary>
    /// <param name="addressDto">Адрес.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Геоданные (широта, долгота).</returns>
    /// <response code="400">Некорректный запрос.</response>
    /// <response code="200">Успешный запрос.</response>
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(List<GeoLocationDto>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetGeoLocationByAddressAsync([FromQuery] AddressDto addressDto,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрос получения геоданных по адресу: '{Address}'",
            JsonConvert.SerializeObject(addressDto));

        var geoLocationByAddress =
            await _geoLocationDataService.GetGeoLocationByAddressAsync(addressDto, cancellationToken);
        
        return Ok(geoLocationByAddress);
    }
}