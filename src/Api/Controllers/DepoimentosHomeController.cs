namespace Api.Controllers;

[ApiController]
[Route("depoimentos-home")]
public class DepoimentosHomeController : ControllerBase
{
    private readonly IDepoimentoAppService _service;

    public DepoimentosHomeController(IDepoimentoAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(DepoimentoDTO[]), Status200OK)]
    public IActionResult GetThreeDepoimentos()
    {
        DepoimentoDTO[] depoimentos = _service.GetThreeRandomDepoimentos();

        return Ok(depoimentos);
    }
}