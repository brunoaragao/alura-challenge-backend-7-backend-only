namespace Core.Dtos;

public sealed record GetThreeRandomTestimonialsResult(
    IReadOnlyCollection<GetThreeRandomTestimonialsResultItem> Items
);