namespace IntegrationTests.Tests;

[Collection(nameof(WebAppFixtureCollection))]
public sealed class TestimonialsEndpointTest
{
    private const string Route = "testimonials";
    private readonly WebAppFixture _app;

    public TestimonialsEndpointTest(WebAppFixture app)
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

    [Fact]
    public async void Get_WithRegistredId_ReturnOk()
    {
        // Arrange
        _app.ReinitializeDataForTests();

        // Act
        var response = await _app.Http.GetAsync($"{Route}/2db6be9c-f3ee-4e9f-b101-15d6624ca600");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void Get_WithUnregistredId_ReturnNotFound()
    {
        // Act
        var response = await _app.Http.GetAsync($"{Route}/00000000-0000-0000-0000-000000000000");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async void Post_ReturnCreated()
    {
        // Act
        var response = await _app.Http.PostAsJsonAsync(
            $"{Route}",
            new CreateTestimonial(
                "Photo 1",
                "Message 1",
                "Author 1"));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async void Post_ReturnBadRequest()
    {
        // Act
        var response = await _app.Http.PostAsJsonAsync(
            Route,
            new CreateTestimonial(null!, null!, null!));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async void Put_ReturnOk()
    {
        // Arrange
        _app.ReinitializeDataForTests();

        // Act
        var response = await _app.Http.PutAsJsonAsync(
            Route,
            new UpdateTestimonial(
                Guid.Parse("2db6be9c-f3ee-4e9f-b101-15d6624ca600"),
                "new photo",
                "new message",
                "new author"));

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void Put_ReturnBadRequest()
    {
        // Act
        var response = await _app.Http.PutAsJsonAsync(
            Route,
            new UpdateTestimonial(
                Guid.Parse("2db6be9c-f3ee-4e9f-b101-15d6624ca600"),
                null!,
                null!,
                null!));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async void Put_ReturnNotFound()
    {
        // Act
        var response = await _app.Http.PutAsJsonAsync(
            Route,
            new UpdateTestimonial(
                Guid.Parse("00000000-0000-0000-0000-000000000000"),
                "new photo",
                "new message",
                "new author"));

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async void Delete_ReturnOk()
    {
        // Arrange
        _app.ReinitializeDataForTests();

        // Act
        var response = await _app.Http.DeleteAsync($"{Route}/2db6be9c-f3ee-4e9f-b101-15d6624ca600");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void Delete_ReturnNotFound()
    {
        // Act
        var response = await _app.Http.DeleteAsync($"{Route}/00000000-0000-0000-0000-000000000000");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}