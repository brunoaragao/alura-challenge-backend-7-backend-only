namespace Core.Services;

public sealed class TestimonialService : ITestimonialService
{
    private readonly ITestimonialRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TestimonialService(
        ITestimonialRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public GetTestimonialResult? GetTestimonial(GetTestimonial request)
    {
        var entity = _repository.GetById(request.Id);

        return entity is not null ?
            new GetTestimonialResult(
                entity.Id,
                entity.Photo,
                entity.Message,
                entity.Author
            ) : null;
    }

    public GetTestimonialsResult GetTestimonials()
    {
        var entities = _repository.GetAll();

        var resultItems = new List<GetTestimonialsResultItem>();

        foreach (var entity in entities)
        {
            resultItems.Add(
                new GetTestimonialsResultItem(
                    entity.Id,
                    entity.Photo,
                    entity.Message,
                    entity.Author));
        }

        return new GetTestimonialsResult(resultItems);
    }

    public GetThreeRandomTestimonialsResult GetThreeRandomTestimonials()
    {
        var entities = _repository.GetThreeRandom();

        var resultItems = entities.Select(
            e => new GetThreeRandomTestimonialsResultItem(
                e.Id,
                e.Photo,
                e.Message,
                e.Author)).ToList();

        return new GetThreeRandomTestimonialsResult(resultItems);
    }

    public CreateTestimonialResult CreateTestimonial(CreateTestimonial request)
    {
        var entity = new Testimonial
        {
            Id = Guid.NewGuid(),
            Photo = request.Photo,
            Message = request.Message,
            Author = request.Author
        };

        _repository.Add(entity);
        _unitOfWork.Commit();

        return new CreateTestimonialResult(
            entity.Id,
            entity.Photo,
            entity.Message,
            entity.Author);
    }

    public UpdateTestimonialResult? UpdateTestimonial(UpdateTestimonial request)
    {
        var entity = _repository.GetById(request.Id);

        if (entity is null)
        {
            return null;
        }

        entity.Photo = request.Photo;
        entity.Message = request.Message;
        entity.Author = request.Author;

        _unitOfWork.Commit();

        return new UpdateTestimonialResult(
            entity.Id,
            entity.Photo,
            entity.Message,
            entity.Author);
    }

    public DeleteTestimonialResult? DeleteTestimonial(DeleteTestimonial request)
    {
        var entity = _repository.GetById(request.Id);

        if (entity is null)
        {
            return null;
        }

        _repository.Delete(entity);
        _unitOfWork.Commit();

        return new DeleteTestimonialResult(
            entity.Id,
            entity.Photo,
            entity.Message,
            entity.Author);
    }
}