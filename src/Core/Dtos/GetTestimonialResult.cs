namespace Core.Dtos;

public sealed record GetTestimonialResult(
    Guid Id,
    string Photo,
    string Message,
    string Author
);