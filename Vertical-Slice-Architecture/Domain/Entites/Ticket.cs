using Vertical_Slice_Architecture.Domain.Base;
using Vertical_Slice_Architecture.Domain.Enums;

namespace Vertical_Slice_Architecture.Domain.Entites;

public sealed class Ticket : Entity, IAuditableEntity, ISoftDeletableEntity
{
    private Ticket(TicketType ticketType, Event @event)
    {
        TicketType = ticketType;
        CreatedOnUtc = DateTime.UtcNow;
        Event = @event;
        IsDeleted = false;
    }

    private Ticket()
    { }

    public TicketType TicketType { get; private set; }
    public bool IsDeleted { get; private set; }

    public DateTime? DeletedOnUtc { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }

    public Guid EventId { get; private set; }
    public Event Event { get; private set; }

    public static Ticket Create(TicketType ticketType, Event @event)
    {
        return new Ticket(ticketType, @event);
    }
}