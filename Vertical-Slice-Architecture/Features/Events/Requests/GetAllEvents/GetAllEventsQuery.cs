using Vertical_Slice_Architecture.Shared.CQRS.Queries;

namespace Vertical_Slice_Architecture.Features.Events.Requests.GetAllEvents;

public sealed record GetAllEventsQuery
    : IQuery<IReadOnlyCollection<GetAllEventResponse>>;