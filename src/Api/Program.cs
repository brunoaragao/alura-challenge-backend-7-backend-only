namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        InitializeDatabase(host);
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

    public static void InitializeDatabase(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        if (services.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
        {
            var dbContext = services.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}