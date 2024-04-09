using Microsoft.EntityFrameworkCore;
using Vertical_Slice_Architecture.Data;
using Vertical_Slice_Architecture.Features.Events.Repository;

namespace Vertical_Slice_Architecture.Shared.Repositories.RepositoryManager;

public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _context;
    private readonly Lazy<IEventRepository> _eventRepository;

    public RepositoryManager(ApplicationDbContext context)
    {
        _context = context;
        _eventRepository = new Lazy<IEventRepository>(() => new EventRepository(_context));
    }

    public IEventRepository EventRepository => _eventRepository.Value;

    public Task<int> CommitAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in _context.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;

                case EntityState.Modified:
                case EntityState.Deleted:
                    await entry.ReloadAsync(cancellationToken);
                    break;
            }
        }
    }
}