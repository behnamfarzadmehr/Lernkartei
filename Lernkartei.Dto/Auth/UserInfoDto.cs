namespace Lernkartei.Dto.Auth;

public record UserInfoDto
{
    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
}
