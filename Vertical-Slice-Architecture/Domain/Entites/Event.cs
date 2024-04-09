using Vertical_Slice_Architecture.Domain.Base;
using Vertical_Slice_Architecture.Domain.Enums;

namespace Vertical_Slice_Architecture.Domain.Entites;

public sealed class Event : Entity, IAuditableEntity, ISoftDeletableEntity
{
    private readonly List<Ticket> _tickets;

    private Event
        (string name,
         string description,
         string location,
         Status status,
         DateTime startDate,
         DateTime endDate)
    {
        Name = name;
        Description = description;
        Location = location;
        Status = status;
        CreatedOnUtc = DateTime.UtcNow;
        _tickets = [];
        StartDate = startDate;
        EndDate = endDate;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public bool IsDeleted { get; private set; }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Status Status { get; private set; }

    public DateTime? DeletedOnUtc { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }

    public IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

    public static Event Create
        (string name,
         string description,
         string location,
         Status status,
         DateTime startDate,
         DateTime endDate)
    {
        return new Event(name, description, location, status, startDate, endDate);
    }

    public static Event Update(
        Event eventToUpdate,
        string name,
        string description,
        string location,
        DateTime startDate,
        DateTime endDate)
    {
        eventToUpdate.Name = name;
        eventToUpdate.Description = description;
        eventToUpdate.Location = location;
        eventToUpdate.StartDate = startDate;
        eventToUpdate.EndDate = endDate;
        eventToUpdate.ModifiedOnUtc = DateTime.UtcNow;
        return eventToUpdate;
    }

    public static Event Remove(Event eventToRemove)
    {
        eventToRemove.IsDeleted = true;
        eventToRemove.DeletedOnUtc = DateTime.UtcNow;
        return eventToRemove;
    }
}