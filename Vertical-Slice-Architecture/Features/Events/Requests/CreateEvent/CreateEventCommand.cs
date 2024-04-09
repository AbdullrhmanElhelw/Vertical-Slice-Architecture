using Vertical_Slice_Architecture.Domain.Enums;
using Vertical_Slice_Architecture.Shared.CQRS.Commands;

namespace Vertical_Slice_Architecture.Features.Events.Requests.CreateEvent;

public sealed record CreateEventCommand
    (
    string Name,
    string Description,
    string Location,
    Status Status,
    DateTime StartDate,
    DateTime EndDate) : ICommand;