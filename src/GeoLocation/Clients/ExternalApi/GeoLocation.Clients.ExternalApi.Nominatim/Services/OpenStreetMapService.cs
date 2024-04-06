using System.Net.Http.Headers;
using GeoLocation.Contracts.AddressDtos;

namespace GeoLocation.Clients.ExternalApi.Nominatim.Services;

/// <inheritdoc />
public class OpenStreetMapService : IOpenStreetMapService
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// </summary>
    /// <param name="httpClient"></param>
    public OpenStreetMapService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://nominatim.openstreetmap.org/");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <inheritdoc />
    public async Task<HttpResponseMessage> GetGeoLocationDataByAddressAsync(AddressRequestDto addressRequest,
        CancellationToken cancellationToken)
    {
        var requestUri =
            $"search?country={addressRequest.Country}&city={addressRequest.City}&street={addressRequest.Street}&format=json&limit=2";

        return await _httpClient.GetAsync(requestUri, cancellationToken);
    }
}