using Vertical_Slice_Architecture.Domain.Entites;
using Vertical_Slice_Architecture.Shared.CQRS.Commands;
using Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Features.Events.Requests.UpdateEvent;

public sealed class UpdateEventCommandHandler
    : ICommandHandler<UpdateEventCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public UpdateEventCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _repositoryManager.EventRepository.GetByIdAsync(request.Id, cancellationToken);
        if (eventToUpdate is null)
            return Result.Failure("Event not found");

        Event.Update(
            eventToUpdate,
            request.Name,
            request.Description,
            request.Location,
            request.StartDate,
            request.EndDate);

        await _repositoryManager.EventRepository.UpdateAsync(eventToUpdate);

        if (await _repositoryManager.CommitAsync(cancellationToken) == 0)
            return Result.Failure("Failed to update event");

        return Result.Success("Updated Successfully");
    }
}