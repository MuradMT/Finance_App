namespace api.Interfaces.Services;

public interface IAccountService
{
    Task<string> RegisterAsync(RegisterDto registerDto);
}
