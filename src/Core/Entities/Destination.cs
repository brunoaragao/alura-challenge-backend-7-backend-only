namespace Core.Entities;

public sealed class Destination : IEntity<Guid>
{
    public Guid Id { get; set; }

    public required string Photo { get; set; }

    public required string Name { get; set; }

    public required decimal Price { get; set; }
}