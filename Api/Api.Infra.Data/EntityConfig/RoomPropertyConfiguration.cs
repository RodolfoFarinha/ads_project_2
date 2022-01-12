using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Room property configuration
    /// </summary>
    internal class RoomPropertyConfiguration : IEntityTypeConfiguration<RoomProperty>
    {
        /// <summary>
        /// Room property configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<RoomProperty> builder)
        {
            builder.ToTable("RoomProperties");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.RoomPropertyKey).IsUnique();
            builder.HasIndex(x => new { x.RoomKey, x.PropertyKey }).IsUnique();

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomProperties)
                .HasPrincipalKey(x => x.RoomKey)
                .HasForeignKey(x => x.RoomKey)            
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Property)
                .WithMany(x => x.PropertyRooms)
                .HasPrincipalKey(x => x.PropertyKey)
                .HasForeignKey(x => x.PropertyKey)                
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
