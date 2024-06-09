

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace api.ServiceRegistration;

// File: ServiceCollectionExtensions.cs
public static class ServiceRegistrationExtension
{
    public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            //opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            opt.UseNpgsql(configuration.GetConnectionString("PgSqlConnection")));



        services.AddIdentity<AppUser, IdentityRole>()//(opt =>
        // {
        //     opt.Password.RequireDigit = true;
        //     opt.Password.RequireLowercase = true;
        //     opt.Password.RequireUppercase = true;
        //     opt.Password.RequireNonAlphanumeric = true;
        //     opt.Password.RequiredLength = 12;
        // })
       .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Finance API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(opt =>
        {
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
        services.AddAuthorization(options =>
        {
            options.AddPolicy("EmailPolicy", policy =>
                policy.RequireClaim("email", "mazahirm48@gmail.com")); // Replace with the email you want to authorize
        });

        services.AddAutoMapper(opt =>
        {
            //builder.Services.AddAutoMapper(typeof(MapperProfile));

            opt.AddMaps(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddScoped<IUnitOfWork<Comment, ApplicationDbContext>, UnitOfWork<Comment, ApplicationDbContext>>();
        services.AddScoped<IUnitOfWork<Stock, ApplicationDbContext>, UnitOfWork<Stock, ApplicationDbContext>>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IPortfolioRepository, PortfolioRepository>();
        services.AddScoped<IFMPRepository, FMPRepository>();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IConverter<Stock, UpdateStockDto>, StockConverter>();
        services.AddScoped<IConverter<Comment, UpdateCommentDto>, CommentConverter>();

        services.AddHttpClient<IFMPRepository,FMPRepository>();
    }
}