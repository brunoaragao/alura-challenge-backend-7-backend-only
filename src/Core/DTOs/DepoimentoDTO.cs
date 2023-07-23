namespace Core.Interfaces;

public record DepoimentoDTO
{
    public long Id { get; init; }
    public required string Mensagem { get; init; }
    public required string NomeAutor { get; init; }
};