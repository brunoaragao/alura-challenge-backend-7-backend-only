namespace Core.Interfaces;

public interface ITestimonialRepository : IGenericRepository<Testimonial, Guid>
{
    IReadOnlyCollection<Testimonial> GetThreeRandom();
}