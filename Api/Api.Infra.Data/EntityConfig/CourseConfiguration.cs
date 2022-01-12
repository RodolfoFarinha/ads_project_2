using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Course configuration
    /// </summary>
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        /// <summary>
        /// Course configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.CourseKey).IsUnique();
        }
    }
}
