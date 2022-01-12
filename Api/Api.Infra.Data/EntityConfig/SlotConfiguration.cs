using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Slot configuration
    /// </summary>
    internal class SlotConfiguration : IEntityTypeConfiguration<Slot>
    {
        /// <summary>
        /// Slot configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder.ToTable("Slots");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SlotKey).IsUnique();

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.Slots)
                .HasPrincipalKey(x => x.SessionKey)
                .HasForeignKey(x => x.SessionKey)              
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.Slots)
                .HasPrincipalKey(x => x.RoomKey)
                .HasForeignKey(x => x.RoomKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
