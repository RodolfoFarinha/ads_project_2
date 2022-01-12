using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Property configuration
    /// </summary>
    internal class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        /// <summary>
        /// Property configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.PropertyKey).IsUnique();
        }
    }
}
