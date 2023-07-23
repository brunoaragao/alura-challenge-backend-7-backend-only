namespace Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddDomainServices()
            .AddApplicationServices()
            .AddDbContext()
            .AddRepositories()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddDefaultCorsPolicy()
            .AddSwagger()
            .AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}