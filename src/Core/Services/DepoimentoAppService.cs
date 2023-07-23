namespace Core.Services;

public class DepoimentoAppService : IDepoimentoAppService
{
    private readonly IDepoimentoService _service;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepoimentoAppService(
        IDepoimentoService service,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _service = service;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public DepoimentoDTO? GetDepoimento(long id)
    {
        var entity = _service.GetDepoimento(id);
        var dto = _mapper.Map<DepoimentoDTO?>(entity);
        return dto;
    }

    public DepoimentoDTO[] GetDepoimentos()
    {
        var entities = _service.GetDepoimentos();
        var dtos = _mapper.Map<DepoimentoDTO[]>(entities);
        return dtos;
    }

    public DepoimentoDTO[] GetThreeRandomDepoimentos()
    {
        var entities = _service.GetThreeRandomDepoimentos();
        var dtos = _mapper.Map<DepoimentoDTO[]>(entities);
        return dtos;
    }

    public void CreateDepoimento(DepoimentoDTO dto)
    {
        var entity = _mapper.Map<Depoimento>(dto);
        _service.CreateDepoimento(entity);
        _unitOfWork.Commit();
    }

    public void CreateOrUpdateDepoimento(DepoimentoDTO dto, out bool created)
    {
        var entity = _mapper.Map<Depoimento>(dto);
        _service.CreateOrUpdateDepoimento(entity, out created);
        _unitOfWork.Commit();
    }

    public void DeleteDepoimento(long id)
    {
        _service.DeleteDepoimento(id);
        _unitOfWork.Commit();
    }
}