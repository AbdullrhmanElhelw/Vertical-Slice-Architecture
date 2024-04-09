using Vertical_Slice_Architecture.Features.Events.Repository;

namespace Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;

public interface IRepositoryManager : IDisposable
{
    IEventRepository EventRepository { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken);

    Task RollbackAsync(CancellationToken cancellationToken);
}