namespace Core.Dtos;

public sealed record GetTestimonialsResultItem(
    Guid Id,
    string Photo,
    string Message,
    string Author
);