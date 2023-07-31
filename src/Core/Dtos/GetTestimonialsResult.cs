namespace Core.Dtos;

public sealed record GetTestimonialsResult(
    IReadOnlyCollection<GetTestimonialsResultItem> Items
);