namespace Core.Interfaces;

public interface IDepoimentoAppService
{
    DepoimentoDTO? GetDepoimento(long id);

    DepoimentoDTO[] GetDepoimentos();

    DepoimentoDTO[] GetThreeRandomDepoimentos();

    void CreateDepoimento(DepoimentoDTO depoimento);

    void CreateOrUpdateDepoimento(DepoimentoDTO depoimento, out bool created);

    void DeleteDepoimento(long id);
}