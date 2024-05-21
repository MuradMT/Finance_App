﻿

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
        services.AddScoped<IStockService, StockService>(); 
        services.AddScoped<ICommentService, CommentService>(); 
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<IConverter<Stock,UpdateStockDto>, StockConverter>();
        services.AddScoped<IConverter<Comment,UpdateCommentDto>,CommentConverter>();
    }
}