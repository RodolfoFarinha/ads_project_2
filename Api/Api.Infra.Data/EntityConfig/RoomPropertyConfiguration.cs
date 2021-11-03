using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    internal class RoomPropertyConfiguration : IEntityTypeConfiguration<RoomProperty>
    {
        public void Configure(EntityTypeBuilder<RoomProperty> builder)
        {
            builder.ToTable("RoomProperties");
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.RoomPropertyKey);
            builder.HasIndex(x => new { x.RoomKey, x.PropertyKey }).IsUnique();

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomProperties)
                .HasForeignKey(x => x.RoomKey)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Property)
                .WithMany(x => x.PropertyRooms)
                .HasForeignKey(x => x.PropertyKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
