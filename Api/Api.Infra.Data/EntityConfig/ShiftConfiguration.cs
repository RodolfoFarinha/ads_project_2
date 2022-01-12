using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Shift configuration
    /// </summary>
    internal class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        /// <summary>
        /// Shift configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Shifts");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ShiftKey).IsUnique();

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.Shifts)
                .HasPrincipalKey(x => x.UnitKey)
                .HasForeignKey(x => x.UnitKey)               
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
