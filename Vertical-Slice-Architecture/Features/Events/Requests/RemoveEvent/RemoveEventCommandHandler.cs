using Vertical_Slice_Architecture.Domain.Entites;
using Vertical_Slice_Architecture.Shared.CQRS.Commands;
using Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Features.Events.Requests.RemoveEvent;

public sealed class RemoveEventCommandHandler
    : ICommandHandler<RemoveEventCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public RemoveEventCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result> Handle(RemoveEventCommand request, CancellationToken cancellationToken)
    {
        var findEvent = await _repositoryManager.EventRepository.GetByIdAsync(request.Id, cancellationToken);

        if (findEvent is null)
            return Result.Failure("Event not found");

        if (findEvent.IsDeleted)
            return Result.Failure("Event already removed");

        Event.Remove(findEvent);
        await _repositoryManager.EventRepository.UpdateAsync(findEvent);
        if (await _repositoryManager.CommitAsync(cancellationToken) == 0)
            return Result.Failure("Failed to remove event");

        return Result.Success("Removed Successfully");
    }
}