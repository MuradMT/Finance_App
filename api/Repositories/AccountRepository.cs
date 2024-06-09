

namespace api.Repositories;

public class AccountRepository(UserManager<AppUser> _userManager,
SignInManager<AppUser> _signInManager, ITokenService _tokenService) : IAccountRepository
{
    public async Task<bool> EmailExistsAsync(string email)
    {
        var userEmail = await _userManager.FindByEmailAsync(email);
        return userEmail is not null;
    }

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName_or_Email) ?? await _userManager.FindByEmailAsync(loginDto.UserName_or_Email);
        if (user == null)
        {
            throw new UnauthorizedAccessException(ConstantMessages.User_Invalid);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException(ConstantMessages.User_Not_Found_Password_Incorrect);
        }
        var token = _tokenService.CreateToken(user);
        return new TokenDto { Token = token, UserName_or_Email = loginDto.UserName_or_Email };

    }

    public async Task<NewUserDto> RegisterAsync(RegisterDto registerDto)
    {
        if (registerDto.UserName == null || registerDto.Email == null)
        {
            throw new ArgumentNullException("Username or Email cannot be null");
        }
        
        if (await UsernameExistsAsync(registerDto.UserName) || await EmailExistsAsync(registerDto.Email))
        {
            throw new UserExistsException(ConstantMessages.User_Already_Exists);
        }
        var newUser = new AppUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
        };
        var result = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (result.Succeeded)
        {
            IdentityResult roleResult;
            if (registerDto.Email == "mammadzade03@gmail.com")
            {
                roleResult = await _userManager.AddToRoleAsync(newUser, "Admin");
            }
            else
            {
                roleResult = await _userManager.AddToRoleAsync(newUser, "User");
            }
            if (roleResult.Succeeded)
            {
                return new NewUserDto()
                {
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,

                };
            }
            else
            {
                throw new Exception(roleResult.Errors.Select(x => x.Description).First());
            }
        }
        else
        {
            throw new Exception(result.Errors.Select(x => x.Description).First());
        }
    }

    public async Task<bool> UsernameExistsAsync(string name)
    {
        var userName = await _userManager.FindByNameAsync(name);
        return userName is not null;
    }
}
