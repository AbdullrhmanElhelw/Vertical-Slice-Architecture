namespace Vertical_Slice_Architecture.Domain.Base;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; protected set; }

    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() ^ 31;
    }
}