using Microsoft.EntityFrameworkCore;

namespace api;

public class ApplicationDbContext:DbContext
{
   public ApplicationDbContext(DbContextOptions options):base(options)
   {
    
   }
   public DbSet<Stock> Stocks { get; set; }
   public DbSet<Comment> Comments { get; set; }
}
