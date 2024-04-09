namespace Vertical_Slice_Architecture.Features.Events.Requests.GetEvent;

public sealed record GetEventResponse
  (
    Guid Id,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime EndDate);