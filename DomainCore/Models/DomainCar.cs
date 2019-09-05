using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Models
{
    public class DomainCar
    {
        public DomainCar(string Name, string CarBrand,int? BrandId, double Price,string ExtencionName,string Info, byte[] image)
        {
            this.Name = Name;
            this.Price = Price;
            this.CarBrand = CarBrand;
            this.BrandId = BrandId;
            this.ExtencionName = ExtencionName;
            this.Info = Info;
            this.image = image;
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
        public virtual ICollection<DomainBuyCar> BuyCars { get; set; }
        public DomainCar()
        {
            BuyCars = new List<DomainBuyCar>();
        }
    }
}
