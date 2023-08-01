namespace Core.Interfaces;

public interface ITestimonialService : IService
{
    GetTestimonialResult? GetTestimonial(GetTestimonial request);
    GetTestimonialsResult GetTestimonials();
    GetThreeRandomTestimonialsResult GetThreeRandomTestimonials();
    CreateTestimonialResult CreateTestimonial(CreateTestimonial request);
    UpdateTestimonialResult? UpdateTestimonial(UpdateTestimonial request);
    DeleteTestimonialResult? DeleteTestimonial(DeleteTestimonial request);
}