using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Unit configuration
    /// </summary>
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        /// <summary>
        /// Unit configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UnitKey).IsUnique();
        }
    }
}
