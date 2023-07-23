namespace Api.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        return services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Name=ConnectionStrings:App"));
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<IDepoimentoRepository, DepoimentoRepository>();
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}