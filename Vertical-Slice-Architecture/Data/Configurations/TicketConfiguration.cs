using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vertical_Slice_Architecture.Domain.Entites;

namespace Vertical_Slice_Architecture.Data.Configurations;

public sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TicketType)
            .HasColumnName("Price")
            .IsRequired();
    }
}