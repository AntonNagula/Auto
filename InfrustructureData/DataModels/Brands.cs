using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureData.DataModels
{
    public class Brands
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public ICollection<Car> Cars { get; set; }
        public Brands()
        {
            Cars = new List<Car>();
        }
    }
}
