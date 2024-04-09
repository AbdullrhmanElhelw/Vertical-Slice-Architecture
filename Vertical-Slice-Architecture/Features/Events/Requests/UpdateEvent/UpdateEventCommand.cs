using Vertical_Slice_Architecture.Shared.CQRS.Commands;

namespace Vertical_Slice_Architecture.Features.Events.Requests.UpdateEvent;

public sealed record UpdateEventCommand
    (
    Guid Id,
    string Name,
    string Description,
    string Location,
    DateTime StartDate,
    DateTime EndDate) : ICommand;