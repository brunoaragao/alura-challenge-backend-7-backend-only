namespace Core.Dtos;

public sealed record CreateDestinationResult(
    Guid Id,
    string Photo,
    string Name,
    decimal Price
);