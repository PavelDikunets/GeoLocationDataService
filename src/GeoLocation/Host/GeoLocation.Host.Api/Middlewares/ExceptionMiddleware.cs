using GeoLocation.Clients.ExternalApi.Nominatim.Exceptions;
using Newtonsoft.Json;

namespace GeoLocation.Host.Api.Middlewares;

/// <summary>
///     Middleware для обработки исключений.
/// </summary>
public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    /// <summary>
    ///     Инициализирует экземпляр <see cref="ExceptionMiddleware" />.
    /// </summary>
    /// <param name="next">Следующий middleware в конвеере.</param>
    /// <param name="logger">Логгер.</param>
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    ///     Вызов следующего middleware в конвеере и перехват исключений.
    /// </summary>
    /// <param name="httpContext">Контекст HTTP-запроса.</param>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (OpenStreetMapException ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла непредвиденная ошибка.");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception is OpenStreetMapException
            ? (int)((OpenStreetMapException)exception).StatusCode
            : 500;

        var result = JsonConvert.SerializeObject(new
            { message = exception.Message, statusCode = context.Response.StatusCode });
        return context.Response.WriteAsync(result);
    }
}