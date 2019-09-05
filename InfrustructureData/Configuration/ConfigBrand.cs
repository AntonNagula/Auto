using InfrustructureData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrustructureData.Configuration
{
    public class ConfigBrand : IEntityTypeConfiguration<Brands>
    {
        public void Configure(EntityTypeBuilder<Brands> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
