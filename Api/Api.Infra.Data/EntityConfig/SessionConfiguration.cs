using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.SessionKey);

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.ShiftKey)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Property)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.PropertyKey)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Room)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.RoomKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
