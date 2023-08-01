namespace IntegrationTests.Tests;

[Collection(nameof(WebAppFixtureCollection))]
public sealed class DestinationsEndpointTest
{
    private const string Route = "destinations";
    private readonly WebAppFixture _app;

    public DestinationsEndpointTest(WebAppFixture app)
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
        var response = await _app.Http.GetAsync($"{Route}/f89f8d63-187c-4e05-ba25-47781275a078");

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
            new CreateDestination("Photo 1", "Name 1", 1M));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async void Post_ReturnBadRequest()
    {
        // Act
        var response = await _app.Http.PostAsJsonAsync(
            Route,
            new CreateDestination(null!, null!, 0M));

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
            new UpdateDestination(
                Guid.Parse("f89f8d63-187c-4e05-ba25-47781275a078"),
                "new photo",
                "new name",
                1M));

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void Put_ReturnBadRequest()
    {
        // Act
        var response = await _app.Http.PutAsJsonAsync(
            Route,
            new UpdateDestination(
                Guid.Parse("f89f8d63-187c-4e05-ba25-47781275a078"),
                null!,
                null!,
                0M));

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async void Put_ReturnNotFound()
    {
        // Act
        var response = await _app.Http.PutAsJsonAsync(
            Route,
            new UpdateDestination(
                Guid.Parse("00000000-0000-0000-0000-000000000000"),
                "new photo",
                "new name",
                1M));

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async void Delete_ReturnOk()
    {
        // Arrange
        _app.ReinitializeDataForTests();

        // Act
        var response = await _app.Http.DeleteAsync($"{Route}/f89f8d63-187c-4e05-ba25-47781275a078");

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