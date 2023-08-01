namespace Core.Services;

public sealed class DestinationService : IDestinationService
{
    private readonly IDestinationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DestinationService(
        IDestinationRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public GetDestinationResult? GetDestination(GetDestination request)
    {
        var entity = _repository.GetById(request.Id);

        return entity is not null ?
            new GetDestinationResult(
                entity.Id,
                entity.Photo,
                entity.Name,
                entity.Price
            ) : null;
    }

    public GetDestinationsResult GetDestinations(GetDestinations request)
    {
        var entities = string.IsNullOrWhiteSpace(request.Name) is false ?
            _repository.GetByName(request.Name) :
            _repository.GetAll();

        var resultItems = new List<GetDestinationsResultItem>();

        foreach (var entity in entities)
        {
            resultItems.Add(
                new GetDestinationsResultItem(
                    entity.Id,
                    entity.Photo,
                    entity.Name,
                    entity.Price));
        }

        return new GetDestinationsResult(resultItems);
    }

    public CreateDestinationResult CreateDestination(CreateDestination request)
    {
        var entity = new Destination
        {
            Id = Guid.NewGuid(),
            Photo = request.Photo,
            Name = request.Name,
            Price = request.Price
        };

        _repository.Add(entity);
        _unitOfWork.Commit();

        return new CreateDestinationResult(
            entity.Id,
            entity.Photo,
            entity.Name,
            entity.Price);
    }

    public UpdateDestinationResult? UpdateDestination(UpdateDestination request)
    {
        var entity = _repository.GetById(request.Id);

        if (entity is null)
        {
            return null;
        }

        entity.Photo = request.Photo;
        entity.Name = request.Name;
        entity.Price = request.Price;

        _unitOfWork.Commit();

        return new UpdateDestinationResult(
            entity.Id,
            entity.Photo,
            entity.Name,
            entity.Price);
    }

    public DeleteDestinationResult? DeleteDestination(DeleteDestination request)
    {
        var entity = _repository.GetById(request.Id);

        if (entity is null)
        {
            return null;
        }

        _repository.Delete(entity);
        _unitOfWork.Commit();

        return new DeleteDestinationResult(
            entity.Id,
            entity.Photo,
            entity.Name,
            entity.Price);
    }
}