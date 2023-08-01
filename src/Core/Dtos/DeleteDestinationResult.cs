namespace Core.Dtos;

public sealed record DeleteDestinationResult(
    Guid Id,
    string Photo,
    string Name,
    decimal Price
);