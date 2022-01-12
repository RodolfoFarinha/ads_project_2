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
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.RoomKey).IsUnique();

            builder
                .HasOne(x => x.Building)
                .WithMany(x => x.Rooms)
                .HasPrincipalKey(x => x.BuildingKey)
                .HasForeignKey(x => x.BuildingKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
