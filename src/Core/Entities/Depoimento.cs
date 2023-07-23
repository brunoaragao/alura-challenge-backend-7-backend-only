namespace Core.Entities;

public class Depoimento : IEntity
{
    public long Id { get; set; }

    // TODO: 😿 Rich Model deve resolver esse default!
    public string Mensagem { get; set; } = default!;

    // TODO: 😿 Rich Model deve resolver esse default!
    public string NomeAutor { get; set; } = default!;
}