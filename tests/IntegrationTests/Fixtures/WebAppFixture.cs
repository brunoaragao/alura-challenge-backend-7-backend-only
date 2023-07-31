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
        db.SaveChanges();
    }

    private static IEnumerable<Testimonial> GetTestimonialsToSeed()
    {
        yield return new() { Id = Guid.Parse("2db6be9c-f3ee-4e9f-b101-15d6624ca600"), Photo = "Photo1", Message = "Message1", Author = "Author1" };
        yield return new() { Id = Guid.Parse("ba9c3da7-8978-4686-b5cf-34b0e92607a0"), Photo = "Photo2", Message = "Message2", Author = "Author2" };
        yield return new() { Id = Guid.Parse("342bfc0d-3ef2-4ba9-a18c-1967bc30d1e1"), Photo = "Photo3", Message = "Message3", Author = "Author3" };
        yield return new() { Id = Guid.Parse("f81c5197-8f85-4d9f-a81d-1e3755be0cf9"), Photo = "Photo4", Message = "Message4", Author = "Author4" };
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