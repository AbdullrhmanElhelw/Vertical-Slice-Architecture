namespace Vertical_Slice_Architecture.Features.Events.Requests.GetAllEvents;

public sealed record GetAllEventResponse
(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime EndDate);