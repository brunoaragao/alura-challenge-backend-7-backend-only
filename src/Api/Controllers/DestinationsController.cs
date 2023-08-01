namespace Api.Controllers;

[ApiController]
[Route("destinations")]
public sealed class DestinationsController : ControllerBase
{
    private readonly IDestinationService _service;

    public DestinationsController(IDestinationService service)
    {
        _service = service;
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(GetDestinationResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetDestinationById([FromRoute] GetDestination request)
    {
        var result = _service.GetDestination(request);

        return result is not null ?
            Ok(result) :
            NotFound();
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetDestinationsResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetDestinations([FromQuery] GetDestinations request)
    {
        var result = _service.GetDestinations(request);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateDestinationResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateDestination(CreateDestination request)
    {
        var result = _service.CreateDestination(request);

        return CreatedAtAction(
            nameof(GetDestinationById),
            new { result.Id },
            result
        );
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateDestinationResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateDestination(UpdateDestination request)
    {
        var result = _service.UpdateDestination(request);

        return result is not null ?
            Ok(result) :
            NotFound();
    }

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteDestinationResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteDestination([FromRoute] DeleteDestination request)
    {
        var result = _service.DeleteDestination(request);

        return result is not null ?
            Ok(result) :
            NotFound();
    }
}