namespace GeoLocation.Contracts.ErrorDtos;

/// <summary>
///     Модель ошибки.
/// </summary>
public class ErrorDto
{
    /// <summary>
    ///     Сообщение об ошибке.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///     Код состояния.
    /// </summary>
    public int StatusCode { get; set; }
}