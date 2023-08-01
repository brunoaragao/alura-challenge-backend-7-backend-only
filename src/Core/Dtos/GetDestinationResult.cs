namespace Core.Dtos;

public sealed record GetDestinationResult(
    Guid Id,
    string Photo,
    string Name,
    decimal Price
);