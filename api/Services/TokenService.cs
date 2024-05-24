

using System.IdentityModel.Tokens.Jwt;

namespace api.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        var signingKey = _config["JWT:SigningKey"];
        if (string.IsNullOrEmpty(signingKey))
        {
            throw new ArgumentException("JWT signing key is not configured.");
        }
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        
    }
    public string CreateToken(AppUser user)
    {
        #region What is Claim,Claim based Authorization,Policy
        //Claims are used for authorization.
        //We call it claim-based-authorization.
        // A claim is a name value pair that represents what the subject is,
        // not what the subject can do.
        //Some codes are used for authorization:
        //builder.Services.AddAuthorization(options =>
        // {
        //    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
        // });
        //[Authorize(Policy = "EmployeeOnly")]
        //[AllowAnonymous]
        #endregion

        var claims = new List<Claim>(){

               new Claim(JwtRegisteredClaimNames.Email,user.Email),

               new Claim(JwtRegisteredClaimNames.GivenName,user.UserName),
        };
        #region What is Signing Credential
        //A signing credential is a combination of a security key and a signing algorithm.
        //The signing algorithm is used to sign the token.
        //The security key is used to verify the token.
        #endregion
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
