namespace IntegrationTests.Fixtures;

public sealed class WebAppFixture : IDisposable
{
    private bool _disposed;

    private readonly CustomWebApplicationFactory<Program> _factory = new();

    public WebAppFixture()
    {
        Http = _factory.CreateClient();

        using var scope = _factory.Services.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.EnsureCreated();
    }

    public HttpClient Http { get; }

    public void ReinitializeDataForTests()
    {
        using var scope = _factory.Services.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var testimonials = db.Set<Testimonial>();
        testimonials.ExecuteDelete();
        testimonials.AddRange(GetTestimonialsToSeed());

        var destinations = db.Set<Destination>();
        destinations.ExecuteDelete();
        destinations.AddRange(GetDestinationsToSeed());

        db.SaveChanges();
    }

    private static IEnumerable<Testimonial> GetTestimonialsToSeed()
    {
        yield return new() { Id = Guid.Parse("2db6be9c-f3ee-4e9f-b101-15d6624ca600"), Photo = "Photo1", Message = "Message1", Author = "Author1" };
        yield return new() { Id = Guid.Parse("ba9c3da7-8978-4686-b5cf-34b0e92607a0"), Photo = "Photo2", Message = "Message2", Author = "Author2" };
        yield return new() { Id = Guid.Parse("342bfc0d-3ef2-4ba9-a18c-1967bc30d1e1"), Photo = "Photo3", Message = "Message3", Author = "Author3" };
        yield return new() { Id = Guid.Parse("f81c5197-8f85-4d9f-a81d-1e3755be0cf9"), Photo = "Photo4", Message = "Message4", Author = "Author4" };
    }

    private static IEnumerable<Destination> GetDestinationsToSeed()
    {
        yield return new() { Id = Guid.Parse("f89f8d63-187c-4e05-ba25-47781275a078"), Photo = "Photo1", Name = "Name1", Price = 1M };
        yield return new() { Id = Guid.Parse("bcf458c1-0ffb-4c82-b5ac-cc863227e1d0"), Photo = "Photo2", Name = "Name2", Price = 2M };
        yield return new() { Id = Guid.Parse("48d284b2-cc5b-4932-83be-b0d57808a22a"), Photo = "Photo3", Name = "Name3", Price = 3M };
        yield return new() { Id = Guid.Parse("86da4084-5d87-4086-83ac-3bc39d868288"), Photo = "Photo4", Name = "Name4", Price = 4M };
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            Http.Dispose();
            _factory.Dispose();
        }

        _disposed = true;
    }
}