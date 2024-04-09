using Vertical_Slice_Architecture.Shared.CQRS.Queries;
using Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Features.Events.Requests.GetAllEvents;

public sealed class GetAllEventQueryHandler
    : IQueryHandler<GetAllEventsQuery, IReadOnlyCollection<GetAllEventResponse>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllEventQueryHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<IReadOnlyCollection<GetAllEventResponse>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await _repositoryManager.EventRepository.GetAllAsync(cancellationToken);

        var response = events
            .Select(e => new GetAllEventResponse(
                e.Id,
                e.Name,
                e.Description,
                e.StartDate,
                e.EndDate))
            .ToList();
        return Result.Success<IReadOnlyCollection<GetAllEventResponse>>(response);
    }
}