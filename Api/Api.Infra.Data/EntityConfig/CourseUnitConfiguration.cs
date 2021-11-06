using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Course unit configuration
    /// </summary>
    internal class CourseUnitConfiguration : IEntityTypeConfiguration<CourseUnit>
    {
        /// <summary>
        /// Course unit configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CourseUnit> builder)
        {
            builder.ToTable("CourseUnits");
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.CourseUnitKey);
            builder.HasIndex(x => new { x.CourseKey, x.UnitKey }).IsUnique();

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseUnits)
                .HasForeignKey(x => x.CourseKey)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.UnitCourses)
                .HasForeignKey(x => x.UnitKey)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
