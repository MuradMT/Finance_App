using Microsoft.EntityFrameworkCore;

namespace api;

public class ApplicationDbContext:DbContext
{
   public DbSet<Stock> Stocks { get; set; }
   public DbSet<Comment> Comments { get; set; }
   

   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
   {
    
   }
   
}
