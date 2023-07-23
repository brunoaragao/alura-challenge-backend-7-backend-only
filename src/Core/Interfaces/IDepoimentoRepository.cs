namespace Core.Interfaces;

public interface IDepoimentoRepository : IGenericRepository<Depoimento>
{
    Depoimento[] GetThreeRandom();
}