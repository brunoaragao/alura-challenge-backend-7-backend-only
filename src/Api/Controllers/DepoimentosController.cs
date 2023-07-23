namespace Api.Controllers;

[ApiController]
[Route("depoimentos")]
public class DepoimentosController : ControllerBase
{
    private readonly IDepoimentoAppService _service;

    public DepoimentosController(IDepoimentoAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(DepoimentoDTO[]), Status200OK)]
    public IActionResult GetDepoimentos()
    {
        DepoimentoDTO[] depoimentos = _service.GetDepoimentos();

        return Ok(depoimentos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DepoimentoDTO), Status200OK)]
    [ProducesResponseType(Status404NotFound)]
    public IActionResult GetDepoimentoById(long id)
    {
        DepoimentoDTO? depoimento = _service.GetDepoimento(id);

        return depoimento is not null ?
            Ok(depoimento) :
            NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(DepoimentoDTO), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public IActionResult CreateDepoimento(DepoimentoDTO depoimento)
    {
        _service.CreateDepoimento(depoimento);

        return CreatedAtAction(
            nameof(GetDepoimentoById),
            new { id = depoimento.Id },
            depoimento);
    }

    [HttpPut]
    [ProducesResponseType(typeof(DepoimentoDTO), Status200OK)]
    [ProducesResponseType(typeof(DepoimentoDTO), Status201Created)]
    [ProducesResponseType(Status400BadRequest)]
    public IActionResult UpdateDepoimento(DepoimentoDTO depoimento)
    {
        _service.CreateOrUpdateDepoimento(depoimento, out bool created);

        return created ?
            CreatedAtAction(
                nameof(GetDepoimentoById),
                new { id = depoimento.Id },
                depoimento) :
            Ok(depoimento);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DepoimentoDTO), Status204NoContent)]
    public IActionResult UpdateDepoimento(long id)
    {
        _service.DeleteDepoimento(id);

        return NoContent();
    }
}