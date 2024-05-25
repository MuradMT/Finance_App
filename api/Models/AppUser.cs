namespace api.Models;

public class AppUser:IdentityUser,IEntity
{
     public List<Portfolio> Portfolios { get; set; }= new List<Portfolio>();
}

