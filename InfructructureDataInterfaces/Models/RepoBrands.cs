using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfructructureDataInterfaces.Models
{
    public class RepoBrands
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public ICollection<RepoCar> Cars { get; set; }
        public RepoBrands()
        {
            Cars = new List<RepoCar>();
        }
    }
}
