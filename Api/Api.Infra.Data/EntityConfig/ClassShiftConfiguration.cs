using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Class shift configuration
    /// </summary>
    internal class ClassShiftConfiguration : IEntityTypeConfiguration<ClassShift>
    {
        /// <summary>
        /// Class shift configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ClassShift> builder)
        {
            builder.ToTable("ClassShifts");
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.ClassShiftKey);
            builder.HasIndex(x => new { x.ClassKey, x.ShiftKey }).IsUnique();

            builder
                .HasOne(x => x.Class)
                .WithMany(x => x.ClassShifts)
                .HasForeignKey(x => x.ClassKey)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.ShiftClasses)
                .HasForeignKey(x => x.ShiftKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
