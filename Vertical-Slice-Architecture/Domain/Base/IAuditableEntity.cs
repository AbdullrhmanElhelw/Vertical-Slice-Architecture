namespace Vertical_Slice_Architecture.Domain.Base;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; }

    DateTime? ModifiedOnUtc { get; }
}