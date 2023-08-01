namespace Core.Dtos;

public sealed record UpdateDestinationResult(
    Guid Id,
    string Photo,
    string Name,
    decimal Price
);