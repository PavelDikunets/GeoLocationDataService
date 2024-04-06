using GeoLocation.Application.AppData.Contexts.GeoLocation.Services;
using GeoLocation.Contracts.AddressDtos;
using GeoLocation.Contracts.ErrorDtos;
using GeoLocation.Contracts.GeoLocationDataDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeoLocation.Host.Api.Controllers;

/// <summary>
///     Контроллер для работы с геоданными.
/// </summary>
[ApiController]
[Route("geolocation")]
public class GeoLocationController : ControllerBase
{
    private readonly IGeoLocationService _geoLocationService;
    private readonly ILogger<GeoLocationController> _logger;

    /// <summary>
    ///     Инициализирует экземпляр <see cref="GeoLocationController" />.
    /// </summary>
    /// <param name="logger">Логгер.</param>
    /// <param name="geoLocationService">Сервис для получения геоданных по адресу.</param>
    public GeoLocationController(ILogger<GeoLocationController> logger,
        IGeoLocationService geoLocationService)
    {
        _logger = logger;
        _geoLocationService = geoLocationService;
    }

    /// <summary>
    ///     Получить геоданные по адресу.
    /// </summary>
    /// <param name="addressRequestDto">Модель адреса для запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список геоданных (широта, долгота).</returns>
    /// <response code="200">Успешный запрос.</response>
    /// <response code="400">Некорректный запрос.</response>
    /// <response code="500">Внутренняя ошибка сервера.</response>
    [ProducesResponseType(typeof(List<GeoLocationDataDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    [HttpGet("geodata")]
    public async Task<IActionResult> GetGeoLocationDataByAddressAsync([FromQuery] AddressRequestDto addressRequestDto,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрос получения геоданных по адресу: '{Address}'",
            JsonConvert.SerializeObject(addressRequestDto));

        var geoLocationDataList =
            await _geoLocationService.GetGeoLocationByAddressAsync(addressRequestDto, cancellationToken);

        return Ok(geoLocationDataList);
    }

    /// <summary>
    ///     Получить ближайшие адреса по геоданным.
    /// </summary>
    /// <param name="geoLocationDataDto">Модель геоданных.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список ближайшийх адресов.</returns>
    /// <response code="200">Успешный запрос.</response>
    /// <response code="400">Некорректный запрос.</response>
    /// <response code="500">Внутренняя ошибка сервера.</response>
    [ProducesResponseType(typeof(List<AddressDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> GetAddressByGeoLocationDataAsync([FromQuery] GeoLocationDataDto geoLocationDataDto,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Запрос получения ближайших адресов по геоданным: '{GeoLocationData}'",
            JsonConvert.SerializeObject(geoLocationDataDto));

        var addressesList =
            await _geoLocationService.GetAddressesByGeoLocationDataAsync(geoLocationDataDto, cancellationToken);

        return Ok(addressesList);
    }
}