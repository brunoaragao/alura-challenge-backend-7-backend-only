namespace Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services.AddScoped<IDepoimentoService, DepoimentoService>();
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddScoped<IDepoimentoAppService, DepoimentoAppService>();
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(Assembly.Load(nameof(Core)));
    }
}