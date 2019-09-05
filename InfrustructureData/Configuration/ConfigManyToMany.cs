using InfrustructureData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrustructureData.Configuration
{
    public class ConfigManyToMany : IEntityTypeConfiguration<BuyCar>
    {
        public void Configure(EntityTypeBuilder<BuyCar> builder)
        {

            builder.HasKey(t => new { t.BuyerId, t.CarId });

            builder
                .HasOne(sc => sc.Buyer)
                .WithMany(s => s.BuyCars)
                .HasForeignKey(sc => sc.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sc => sc.Car)
                .WithMany(s => s.BuyCars)
                .HasForeignKey(sc => sc.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}