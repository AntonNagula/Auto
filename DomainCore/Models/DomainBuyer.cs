using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Models
{
    public class DomainBuyer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual ICollection<DomainBuyCar> BuyCars { get; set; }
        public DomainBuyer()
        {
            BuyCars = new List<DomainBuyCar>();
        }
    }
}
