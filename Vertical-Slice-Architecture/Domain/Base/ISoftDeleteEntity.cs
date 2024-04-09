namespace Vertical_Slice_Architecture.Domain.Base;

public interface ISoftDeletableEntity
{
    bool IsDeleted { get; }
    DateTime? DeletedOnUtc { get; }
}