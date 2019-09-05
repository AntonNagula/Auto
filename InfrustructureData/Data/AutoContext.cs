using InfructructureDataInterfaces.Repositories;
using InfrustructureData.Configuration;
using InfrustructureData.DataModels;
using Microsoft.EntityFrameworkCore;
namespace InfrustructureData.Data
{
    public class AutoContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<BuyCar> BuyCars { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public AutoContext(DbContextOptions<AutoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public AutoContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ShopAutoContext;Trusted_Connection=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigManyToMany());
            modelBuilder.ApplyConfiguration(new ConfigCar());
            modelBuilder.ApplyConfiguration(new ConfigBuyer());
            modelBuilder.ApplyConfiguration(new ConfigBrand());
            base.OnModelCreating(modelBuilder);
        }
    }
}
