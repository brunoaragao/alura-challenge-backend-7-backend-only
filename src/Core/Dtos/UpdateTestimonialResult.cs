namespace Core.Dtos;

public sealed record UpdateTestimonialResult(
    Guid Id,
    string Photo,
    string Message,
    string Author
);