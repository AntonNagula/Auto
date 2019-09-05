using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auto.ModelsApp
{
    public class AppCar
    {
        public AppCar(string Name, string CarBrand, double Price,string Info)
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
        public virtual ICollection<AppBuyCar> BuyCars { get; set; }
        public AppCar()
        {
            BuyCars = new List<AppBuyCar>();
        }
    }
}