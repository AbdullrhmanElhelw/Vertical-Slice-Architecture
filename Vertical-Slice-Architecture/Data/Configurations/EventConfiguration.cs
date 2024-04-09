using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vertical_Slice_Architecture.Domain.Entites;

namespace Vertical_Slice_Architecture.Data.Configurations;

public sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Location)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.EndDate)
            .IsRequired();

        builder.HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId)
            .HasConstraintName("FK_Tickets_Events")
            .OnDelete(DeleteBehavior.Cascade);
    }
}