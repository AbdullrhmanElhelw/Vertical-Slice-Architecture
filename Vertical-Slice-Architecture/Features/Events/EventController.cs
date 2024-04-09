using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vertical_Slice_Architecture.Features.Events.Requests.CreateEvent;
using Vertical_Slice_Architecture.Features.Events.Requests.GetAllEvents;
using Vertical_Slice_Architecture.Features.Events.Requests.GetEvent;
using Vertical_Slice_Architecture.Features.Events.Requests.RemoveEvent;
using Vertical_Slice_Architecture.Features.Events.Requests.UpdateEvent;
using Vertical_Slice_Architecture.Shared.ResponseResult;

namespace Vertical_Slice_Architecture.Features.Events;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly ISender _sender;

    public EventController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CreateEventCommand>> CreateEvent([FromBody] CreateEventCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match<ActionResult<CreateEventCommand>>(
            onSuccess: () => Ok(command),
            onFailure: error => BadRequest(error)
        );
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<GetAllEventResponse>>> GetAllEvents()
    {
        var result = await _sender.Send(new GetAllEventsQuery());
        return result.Match<ActionResult<IReadOnlyCollection<GetAllEventResponse>>>(
            onSuccess: () => Ok(result.Value),
            onFailure: error => BadRequest(error)
            );
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetAllEventResponse>> GetEventById(Guid id)
    {
        var result = await _sender.Send(new GetEventQuery(id));
        return result.Match<ActionResult<GetAllEventResponse>>(
            onSuccess: () => Ok(result.Value),
            onFailure: error => BadRequest(error));
    }

    [HttpPut]
    public async Task<ActionResult<UpdateEventCommand>> UpdateEvent([FromBody] UpdateEventCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match<ActionResult<UpdateEventCommand>>(
            onSuccess: () => Ok(command),
            onFailure: error => BadRequest(error));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<RemoveEventCommand>> DeleteEvent(Guid id)
    {
        var result = await _sender.Send(new RemoveEventCommand(id));
        return result.Match<ActionResult<RemoveEventCommand>>(
            onSuccess: () => Ok(result),
            onFailure: error => BadRequest(error)
           );
    }
}