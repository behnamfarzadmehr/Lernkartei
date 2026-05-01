namespace Lernkartei.Dto.Auth;

public record Response
{
    public string Status { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}
