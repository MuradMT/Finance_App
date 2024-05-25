namespace api.Extensions;

public static class ClaimsExtension
{
      public static string GetUserEmail(this ClaimsPrincipal user)
      {
            return user.FindFirst(ClaimTypes.Email)?.Value;
      }

      public static string GetUserName(this ClaimsPrincipal user)
      {
            return user.FindFirst(ClaimTypes.GivenName)?.Value;
      }
}
