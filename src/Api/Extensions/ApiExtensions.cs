namespace Api.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection AddDefaultCorsPolicy(this IServiceCollection services)
    {
        return services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()));
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }
}