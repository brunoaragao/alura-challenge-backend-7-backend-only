namespace Core.Interfaces;

public interface IDestinationRepository : IGenericRepository<Destination, Guid>
{
    IReadOnlyCollection<Destination> GetByName(string name);
}