namespace Core.Interfaces;

public interface IDestinationService : IService
{
    GetDestinationResult? GetDestination(GetDestination request);
    GetDestinationsResult GetDestinations(GetDestinations request);
    CreateDestinationResult CreateDestination(CreateDestination request);
    UpdateDestinationResult? UpdateDestination(UpdateDestination request);
    DeleteDestinationResult? DeleteDestination(DeleteDestination request);
}