namespace Api.Controllers;

[ApiController]
[Route("testimonials-home")]
public sealed class TestimonialsHomeController : ControllerBase
{
    private readonly ITestimonialService _service;

    public TestimonialsHomeController(ITestimonialService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetThreeRandomTestimonialsResult), StatusCodes.Status200OK)]
    public IActionResult GetThreeRandomTestimonials()
    {
        var result = _service.GetThreeRandomTestimonials();

        return Ok(result);
    }
}