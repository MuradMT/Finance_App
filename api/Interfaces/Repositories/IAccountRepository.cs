namespace api.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> UsernameExistsAsync(string username);
}
