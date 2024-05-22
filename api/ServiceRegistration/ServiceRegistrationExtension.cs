namespace api.ServiceRegistration;

// File: ServiceCollectionExtensions.cs
public static class ServiceRegistrationExtension
{
    public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddAutoMapper(opt =>
        {
            //builder.Services.AddAutoMapper(typeof(MapperProfile));

            opt.AddMaps(Assembly.GetExecutingAssembly());
        });
        services.AddScoped<IUnitOfWork<Comment, ApplicationDbContext>, UnitOfWork<Comment, ApplicationDbContext>>();
        services.AddScoped<IUnitOfWork<Stock, ApplicationDbContext>, UnitOfWork<Stock, ApplicationDbContext>>();
        services.AddScoped<IStockService, StockService>(); 
        services.AddScoped<ICommentService, CommentService>(); 
        services.AddScoped<IConverter<Stock,UpdateStockDto>, StockConverter>();
        services.AddScoped<IConverter<Comment,UpdateCommentDto>,CommentConverter>();
    }
}