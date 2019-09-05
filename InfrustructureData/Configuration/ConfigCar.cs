using InfrustructureData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InfrustructureData.Configuration
{
    public class ConfigCar : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(sc => sc.Brand)
                .WithMany(s => s.Cars)
                .HasForeignKey(sc => sc.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(sc => sc.Owner)
                .WithMany(s => s.Cars)
                .HasForeignKey(sc => sc.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
