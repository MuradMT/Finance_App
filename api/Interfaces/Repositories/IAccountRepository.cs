namespace api.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<NewUserDto> RegisterAsync(RegisterDto registerDto);
    Task<TokenDto> LoginAsync(LoginDto loginDto);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> UsernameExistsAsync(string username);
}
