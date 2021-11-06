using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Room configuration
    /// </summary>
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        /// <summary>
        /// Room configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.RoomKey);

            builder
                .HasOne(x => x.Building)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.BuildingKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
