namespace Core.Services;

public class DepoimentoService : IDepoimentoService
{
    private readonly IDepoimentoRepository _repository;

    public DepoimentoService(IDepoimentoRepository repository)
    {
        _repository = repository;
    }

    public Depoimento? GetDepoimento(long id)
    {
        return _repository.Get(id);
    }

    public Depoimento[] GetDepoimentos()
    {
        return _repository.Get();
    }

    public Depoimento[] GetThreeRandomDepoimentos()
    {
        return _repository.GetThreeRandom();
    }

    public void CreateDepoimento(Depoimento depoimento)
    {
        _repository.Add(depoimento);
    }

    public void CreateOrUpdateDepoimento(
        Depoimento depoimento,
        out bool created)
    {
        _repository.AddOrUpdate(depoimento, out created);
    }

    public void DeleteDepoimento(long id)
    {
        _repository.Remove(id);
    }
}