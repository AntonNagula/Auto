using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfructructureDataInterfaces.Models
{
    public class RepoBuyer
    {        
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual ICollection<RepoBuyCar> BuyCars { get; set; }
        public RepoBuyer()
        {
            BuyCars = new List<RepoBuyCar>();
        }
    }
}
