using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Session configuration
    /// </summary>
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        /// <summary>
        /// Session configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SessionKey).IsUnique();

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.Sessions)
                .HasPrincipalKey(x => x.ShiftKey)
                .HasForeignKey(x => x.ShiftKey)              
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Property)
                .WithMany(x => x.Sessions)
                .HasPrincipalKey(x => x.PropertyKey)
                .HasForeignKey(x => x.PropertyKey)              
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
