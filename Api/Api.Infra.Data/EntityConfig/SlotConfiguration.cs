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
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.SlotKey);

            builder
                .HasOne(x => x.Session)
                .WithMany(x => x.Slots)
                .HasForeignKey(x => x.SessionKey)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.Slots)
                .HasForeignKey(x => x.RoomKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
