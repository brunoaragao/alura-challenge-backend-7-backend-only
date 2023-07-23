namespace UnitTest;

public class DepoimentoServiceTests
{
    private readonly DepoimentoService _service;
    private readonly Mock<IDepoimentoRepository> _repositoryMock;

    public DepoimentoServiceTests()
    {
        _repositoryMock = new();

        _service = new(_repositoryMock.Object);
    }

    [Fact]
    public void GetDepoimento_WhenDepoimentoExists_ReturnDepoimento()
    {
        // Arrange
        const long id = default;
        Depoimento existing = new() { Id = id };

        _repositoryMock
            .Setup(r => r.Get(id))
            .Returns(existing);

        // Act
        Depoimento? retrieved = _service.GetDepoimento(id);

        // Assert
        Assert.NotNull(retrieved);
        Assert.Same(existing, retrieved);
    }

    [Fact]
    public void GetDepoimento_WhenDepoimentoNotExists_ReturnNull()
    {
        // Arrange
        const long id = default;

        _repositoryMock
            .Setup(r => r.Get(id))
            .Returns((Depoimento?)null);

        // Act
        Depoimento? retrieved = _service.GetDepoimento(id);

        // Assert
        Assert.Null(retrieved);
    }

    [Fact]
    public void GetDepoimentos_WhenThereIsDepoimentos_ReturnNonEmptyArray()
    {
        // Arrange
        Depoimento[] existing = { new(), new(), new() };

        _repositoryMock
            .Setup(r => r.Get())
            .Returns(existing);

        // Act
        Depoimento[] retrieved = _service.GetDepoimentos();

        // Assert
        Assert.NotNull(retrieved);
        Assert.Same(existing, retrieved);
        Assert.NotEmpty(retrieved);
    }

    [Fact]
    public void GetDepoimentos_WhenThereIsNotDepoimentos_ReturnEmptyArray()
    {
        // Arrange
        Depoimento[] existing = Array.Empty<Depoimento>();

        _repositoryMock
            .Setup(r => r.Get())
            .Returns(existing);

        // Act
        Depoimento[] retrieved = _service.GetDepoimentos();

        // Assert
        Assert.NotNull(retrieved);
        Assert.Same(existing, retrieved);
        Assert.Empty(retrieved);
    }

    [Fact]
    public void GetThreeRandomDepoimentos_WhenThereIsThreeDepoimentos_ReturnThreeRandom()
    {
        // Arrange
        Depoimento[] random = { new(), new(), new() };

        _repositoryMock
            .Setup(r => r.GetThreeRandom())
            .Returns(random);

        // Act
        Depoimento[] retrieved = _service.GetThreeRandomDepoimentos();

        // Assert
        Assert.NotNull(retrieved);
        Assert.Same(random, retrieved);
        Assert.NotEmpty(retrieved);
    }

    [Fact]
    public void GetThreeRandomDepoimentos_WhenThereAreLessThanThreeDepoimentos_ReturnAnArrayWithLessThanThreeDepoimentos()
    {
        // Arrange
        Depoimento[] random = Array.Empty<Depoimento>();

        _repositoryMock
            .Setup(r => r.GetThreeRandom())
            .Returns(random);

        // Act
        Depoimento[] retrieved = _service.GetThreeRandomDepoimentos();

        // Assert
        Assert.NotNull(retrieved);
        Assert.Same(random, retrieved);
        Assert.Empty(retrieved);
    }

    [Fact]
    public void CreateDepoimento_Ever_AddInRepository()
    {
        // Arrange
        Depoimento depoimento = new();

        // Act
        _service.CreateDepoimento(depoimento);

        // Assert
        _repositoryMock.Verify(r => r.Add(depoimento), Times.Once);
    }

    [Fact]
    public void CreateOrUpdateDepoimento_Always_AddOrUpdateInRepository()
    {
        // Arrange
        Depoimento depoimento = new();

        // Act
        _service.CreateOrUpdateDepoimento(depoimento, out bool added);

        // Assert
        _repositoryMock.Verify(r => r.AddOrUpdate(depoimento, out added), Times.Once);
    }

    [Fact]
    public void DeleteDepoimento_Always_RemoveFromRepository()
    {
        // Arrange
        const long id = default;

        // Act
        _service.DeleteDepoimento(id);

        // Assert
        _repositoryMock.Verify(r => r.Remove(id), Times.Once);
    }
}