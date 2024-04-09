using Vertical_Slice_Architecture.Data;
using Vertical_Slice_Architecture.Domain.Entites;
using Vertical_Slice_Architecture.Shared.Repositories.MainRepository;

namespace Vertical_Slice_Architecture.Features.Events.Repository;

public sealed class EventRepository : GenericRepository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context) : base(context)
    {
    }
}