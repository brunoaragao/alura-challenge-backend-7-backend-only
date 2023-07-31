namespace Core.Dtos;

public sealed record DeleteTestimonialResult(
    Guid Id,
    string Photo,
    string Message,
    string Author
);