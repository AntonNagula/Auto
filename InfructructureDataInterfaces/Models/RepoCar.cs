using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfructructureDataInterfaces.Models
{
    public class RepoCar
    {
        public RepoCar(string Name, string CarBrand, double Price)
        {
            this.Name = Name;
            this.Price = Price;
            this.CarBrand = CarBrand;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExtencionName { get; set; }
        public string CarBrand { get; set; }
        public int? BrandId { get; set; }
        public int? OwnerId { get; set; }
        public double Price { get; set; }
        public byte[] image { get; set; }
        public string Info { get; set; }
        public virtual ICollection<RepoBuyCar> BuyCars { get; set; }
        public RepoCar()
        {
            BuyCars = new List<RepoBuyCar>();
        }
    }
}
