namespace Api.Controllers;

[ApiController]
[Route("testimonials")]
public sealed class TestimonialsController : ControllerBase
{
    private readonly ITestimonialService _service;

    public TestimonialsController(ITestimonialService service)
    {
        _service = service;
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(GetTestimonialResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetTestimonialById([FromRoute] GetTestimonial request)
    {
        var result = _service.GetTestimonial(request);

        return result is not null ?
            Ok(result) :
            NotFound();
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetTestimonialsResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAllTestimonials()
    {
        var result = _service.GetTestimonials();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateTestimonialResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateTestimonial(CreateTestimonial request)
    {
        var result = _service.CreateTestimonial(request);

        return CreatedAtAction(
            nameof(GetTestimonialById),
            new { result.Id },
            result
        );
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateTestimonialResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateTestimonial(UpdateTestimonial request)
    {
        var result = _service.UpdateTestimonial(request);

        return result is not null ?
            Ok(result) :
            NotFound();
    }

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteTestimonialResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTestimonial([FromRoute] DeleteTestimonial request)
    {
        var result = _service.DeleteTestimonial(request);

        return result is not null ?
            Ok(result) :
            NotFound();
    }
}