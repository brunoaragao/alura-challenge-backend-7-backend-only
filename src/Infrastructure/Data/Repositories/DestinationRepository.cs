namespace Infrastructure.Data.Repositories;

public sealed class DestinationRepository : GenericRepository<Destination, Guid>, IDestinationRepository
{
    public DestinationRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IReadOnlyCollection<Destination> GetByName(string search)
    {
        return _dbSet
            .Where(d => d.Name.Contains(search))
            .ToList();
    }
}