

using System.Reflection.Metadata.Ecma335;

namespace api.Repositories;

public class AccountRepository(UserManager<AppUser> _userManager) : IAccountRepository
{
    public async Task<bool> EmailExistsAsync(string email)
    {
        var userEmail = await _userManager.FindByEmailAsync(email);
        return userEmail is not null;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        if (await UsernameExistsAsync(registerDto.UserName) || await EmailExistsAsync(registerDto.Email))
        {
            throw new UserExistsException(ConstantMessages.User_Already_Exists);
        }
        var newUser = new AppUser
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
        };
        var result = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (result.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(newUser, "User");
            if (roleResult.Succeeded)
            {
                return ConstantMessages.User_Created;
            }
            else
            {
                throw new Exception(roleResult.Errors.Select(x=>x.Description).First());
            }
        }
        else
        {
            throw new Exception(result.Errors.Select(x=>x.Description).First());
        }
    }

    public async Task<bool> UsernameExistsAsync(string name)
    {
        var userName = await _userManager.FindByNameAsync(name);
        return userName is not null;
    }
}
