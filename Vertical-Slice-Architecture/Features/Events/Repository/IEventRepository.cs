using Vertical_Slice_Architecture.Domain.Entites;
using Vertical_Slice_Architecture.Shared.Repositories.MainRepository;

namespace Vertical_Slice_Architecture.Features.Events.Repository;

public interface IEventRepository : IGenericRepository<Event>
{
}