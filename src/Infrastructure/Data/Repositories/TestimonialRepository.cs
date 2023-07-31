namespace Infrastructure.Data.Repositories;

public sealed class TestimonialRepository : GenericRepository<Testimonial, Guid>, ITestimonialRepository
{
    public TestimonialRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IReadOnlyCollection<Testimonial> GetThreeRandom()
    {
        return _dbSet
            .OrderBy(_ => Guid.NewGuid())
            .Take(3)
            .ToList();
    }
}