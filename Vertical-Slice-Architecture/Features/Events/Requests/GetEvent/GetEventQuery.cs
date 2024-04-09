using Vertical_Slice_Architecture.Shared.CQRS.Queries;

namespace Vertical_Slice_Architecture.Features.Events.Requests.GetEvent;

public sealed record GetEventQuery(Guid Id)
    : IQuery<GetEventResponse>;