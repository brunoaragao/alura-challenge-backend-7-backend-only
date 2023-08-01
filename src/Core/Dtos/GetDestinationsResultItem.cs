namespace Core.Dtos;

public sealed record GetDestinationsResultItem(
    Guid Id,
    string Photo,
    string Name,
    decimal Price
);