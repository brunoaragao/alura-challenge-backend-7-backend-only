namespace IntegrationTests.Tests;

[Collection(nameof(WebAppFixtureCollection))]
public sealed class TestimonialsHomeEndpointTest
{
    private const string Route = "testimonials-home";
    private readonly WebAppFixture _app;

    public TestimonialsHomeEndpointTest(WebAppFixture app)
    {
        _app = app;
    }

    [Fact]
    public async void Get_ReturnOk()
    {
        // Act
        var response = await _app.Http.GetAsync(Route);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}