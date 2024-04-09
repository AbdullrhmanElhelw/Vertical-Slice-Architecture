using Vertical_Slice_Architecture.Shared.CQRS.Queries;
using Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Features.Events.Requests.GetEvent;

public sealed class GetEventQueryHandler
    : IQueryHandler<GetEventQuery, GetEventResponse>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetEventQueryHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<GetEventResponse>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await _repositoryManager.EventRepository.GetByIdAsync(request.Id, cancellationToken);
        if (eventEntity is null)
            return Result.Failure<GetEventResponse>("Event not found");

        return Result.Success(new GetEventResponse(
            eventEntity.Id,
            eventEntity.Name,
            eventEntity.Description,
            eventEntity.StartDate,
            eventEntity.EndDate));
    }
}