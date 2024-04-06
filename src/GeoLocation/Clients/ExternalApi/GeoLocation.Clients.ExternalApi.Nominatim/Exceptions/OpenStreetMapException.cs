using System.Net;

namespace GeoLocation.Clients.ExternalApi.Nominatim.Exceptions;

/// <summary>
///     Исключение для OpenStreetMap API.
/// </summary>
public class OpenStreetMapException : Exception
{
    /// <summary>
    ///     Инициализирует экземпляр <see cref="OpenStreetMapException" />.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="statusCode">Код состояния.</param>
    public OpenStreetMapException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    ///     Код состояния.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }
}