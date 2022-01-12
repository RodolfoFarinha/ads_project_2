using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.EntityConfig
{
    /// <summary>
    /// Class configuration
    /// </summary>
    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        /// <summary>
        /// Class configuration builder
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ClassKey).IsUnique();
        }
    }
}
