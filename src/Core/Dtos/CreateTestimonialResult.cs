namespace Core.Dtos;

public sealed record CreateTestimonialResult(
    Guid Id,
    string Photo,
    string Message,
    string Author
);