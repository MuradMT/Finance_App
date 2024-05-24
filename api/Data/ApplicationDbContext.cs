

namespace api.Data;

public class ApplicationDbContext:IdentityDbContext<AppUser>
{
   public DbSet<Stock> Stocks { get; set; }
   public DbSet<Comment> Comments { get; set; }
   

   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
   {
    
   }
   
}
