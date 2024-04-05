namespace GeoLocation.Contracts.ErrorDtos;

/// <summary>
///     Обертка для модели ошибки.
/// </summary>
public class ErrorWrapperDto
{
    /// <summary>
    ///     Модель ошибки.
    /// </summary>
    public ErrorDto Error { get; set; }
}