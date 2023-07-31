namespace Core.Dtos;

public sealed record UpdateTestimonial(
    Guid Id,
    string Photo,
    string Message,
    string Author
);