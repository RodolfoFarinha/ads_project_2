using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Quality schedule configuration
    /// </summary>
    internal class QualityScheduleConfiguration : IEntityTypeConfiguration<QualitySchedule>
    {
        /// <summary>
        /// Quality schedule configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<QualitySchedule> builder)
        {
            builder.ToTable("QualitySchedules");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ScheduleKey).IsUnique();
        }
    }
}
