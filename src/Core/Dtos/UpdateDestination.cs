namespace Core.Dtos;

public sealed record UpdateDestination(
    Guid Id,
    string Photo,
    string Name,
    decimal Price
);