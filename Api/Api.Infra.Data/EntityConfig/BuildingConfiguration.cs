using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Building configuration
    /// </summary>
    internal class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        /// <summary>
        /// Building configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.BuildingKey).IsUnique();
        }
    }
}
