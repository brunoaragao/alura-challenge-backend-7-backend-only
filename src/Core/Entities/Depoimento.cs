namespace Core.Entities;

public sealed class Testimonial : IEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Photo { get; set; }
    public required string Message { get; set; }
    public required string Author { get; set; }
}