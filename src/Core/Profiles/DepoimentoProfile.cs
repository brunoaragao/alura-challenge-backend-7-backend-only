namespace Core.Pofiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<Depoimento, DepoimentoDTO>();
        CreateMap<DepoimentoDTO, Depoimento>();
    }
}