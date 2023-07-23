namespace Infra.Data.Repositories;

public class DepoimentoRepository :
    GenericRepository<Depoimento>,
    IDepoimentoRepository
{
    public DepoimentoRepository(AppDbContext context)
        : base(context)
    {
    }

    public Depoimento[] GetThreeRandom()
    {
        return _set.OrderBy(d => Guid.NewGuid())
            .Take(3)
            .ToArray();
    }
}