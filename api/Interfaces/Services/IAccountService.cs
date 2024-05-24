namespace api.Interfaces.Services;

public interface IAccountService
{
    Task<NewUserDto> RegisterAsync(RegisterDto registerDto);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
}
