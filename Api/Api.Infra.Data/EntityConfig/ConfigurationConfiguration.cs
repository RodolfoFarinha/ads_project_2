using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Configuration configuration
    /// </summary>
    internal class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        /// <summary>
        /// Configuration configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable("Configurations");
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.ConfigurationKey);
        }
    }
}
