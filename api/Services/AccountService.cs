
namespace api.Services;

public class AccountService(IAccountRepository _accountRepository) : IAccountService
{
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        return await _accountRepository.RegisterAsync(registerDto);

    }

}
