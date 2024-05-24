namespace api.Interfaces.Services;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}
