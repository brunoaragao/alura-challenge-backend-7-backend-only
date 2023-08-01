namespace Core.Dtos;

public sealed record GetDestinationsResult(
    IReadOnlyCollection<GetDestinationsResultItem> Items
);