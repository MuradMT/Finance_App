

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace api.ServiceRegistration;

// File: ServiceCollectionExtensions.cs
public static class ServiceRegistrationExtension
{
    public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireNonAlphanumeric = true;
            opt.Password.RequiredLength = 12;
            opt.User.RequireUniqueEmail = true;
        })
       .AddEntityFrameworkStores<ApplicationDbContext>();

       services.AddAuthentication(opt =>{
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;

       }).AddJwtBearer(opt=>{
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])),
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"],//Issuer is basically server
            ValidateAudience = true,
            ValidAudience = configuration["JWT:Audience"],//Audience is basically client
        };
       });

        services.AddAutoMapper(opt =>
        {
            //builder.Services.AddAutoMapper(typeof(MapperProfile));

            opt.AddMaps(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddScoped<IUnitOfWork<Comment, ApplicationDbContext>, UnitOfWork<Comment, ApplicationDbContext>>();
        services.AddScoped<IUnitOfWork<Stock, ApplicationDbContext>, UnitOfWork<Stock, ApplicationDbContext>>();

        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IConverter<Stock, UpdateStockDto>, StockConverter>();
        services.AddScoped<IConverter<Comment, UpdateCommentDto>, CommentConverter>();
    }
}