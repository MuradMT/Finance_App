
namespace api.Services;

public class AccountService(IAccountRepository _accountRepository) : IAccountService
{
    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        return await _accountRepository.LoginAsync(loginDto);
    }

    public async Task<NewUserDto> RegisterAsync(RegisterDto registerDto)
    {
        return await _accountRepository.RegisterAsync(registerDto);

    }

}
