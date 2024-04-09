using Vertical_Slice_Architecture.Shared.CQRS.Commands;

namespace Vertical_Slice_Architecture.Features.Events.Requests.RemoveEvent;

public sealed record RemoveEventCommand
    (Guid Id) : ICommand;