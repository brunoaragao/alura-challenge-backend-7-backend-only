namespace Core.Dtos;

public sealed record GetThreeRandomTestimonialsResultItem(
    Guid Id,
    string Photo,
    string Message,
    string Author
);