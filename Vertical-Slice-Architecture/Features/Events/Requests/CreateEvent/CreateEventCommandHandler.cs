using Vertical_Slice_Architecture.Domain.Entites;
using Vertical_Slice_Architecture.Shared.CQRS.Commands;
using Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Features.Events.Requests.CreateEvent;

public sealed class CreateEventCommandHandler
     : ICommandHandler<CreateEventCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public CreateEventCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public Task<Result> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = Event.Create(request.Name,
                        request.Description,
                        request.Location,
                        request.Status,
                        request.StartDate,
                        request.EndDate);

        var addEventTask = _repositoryManager.EventRepository.AddAsync(@event, cancellationToken);
        var commitTask = _repositoryManager.CommitAsync(cancellationToken);

        return Task.WhenAll(addEventTask, commitTask)
            .ContinueWith(task =>
            {
                if (commitTask.Result == 0)
                    return Result.Failure("Failed to create event");
                return Result.Success();
            }, cancellationToken);
    }
}