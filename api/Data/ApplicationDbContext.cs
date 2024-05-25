namespace api.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
   public DbSet<Stock> Stocks { get; set; }
   public DbSet<Comment> Comments { get; set; }
   public DbSet<Portfolio> Portfolios { get; set; }


   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {

   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      #region Many to Many relationship configuration

      builder.Entity<Portfolio>(x=>x.HasKey(p=>new{p.AppUserId,p.StockId}));

      builder.Entity<Portfolio>()
      .HasOne(x=>x.AppUser)
      .WithMany(x=>x.Portfolios)
      .HasForeignKey(x=>x.AppUserId);

      builder.Entity<Portfolio>()
      .HasOne(x=>x.Stock)
      .WithMany(x=>x.Portfolios)
      .HasForeignKey(x=>x.StockId);

      #endregion

      List<IdentityRole> roles = new List<IdentityRole>(){
          new IdentityRole{Name="Admin",NormalizedName="ADMIN"},
          new IdentityRole{Name="User",NormalizedName="USER"}
        };

      builder.Entity<IdentityRole>().HasData(roles);
   }

}
