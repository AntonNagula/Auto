using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureData.DataModels
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual ICollection<BuyCar> BuyCars { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Buyer()
        {
            BuyCars = new List<BuyCar>();
            Cars = new List<Car>();
        }
    }
}
