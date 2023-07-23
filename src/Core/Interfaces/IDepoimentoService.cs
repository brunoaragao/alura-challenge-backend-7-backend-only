namespace Core.Interfaces;

public interface IDepoimentoService
{
    Depoimento? GetDepoimento(long id);

    Depoimento[] GetDepoimentos();

    Depoimento[] GetThreeRandomDepoimentos();

    void CreateDepoimento(Depoimento depoimento);

    void CreateOrUpdateDepoimento(Depoimento depoimento, out bool created);

    void DeleteDepoimento(long id);
}