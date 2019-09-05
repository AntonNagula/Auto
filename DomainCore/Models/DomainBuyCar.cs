using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Models
{
    public class DomainBuyCar
    {
        public int CarId { get; set; }
        public DomainCar Car { get; set; }

        public int BuyerId { get; set; }
        public DomainBuyer Buyer { get; set; }

       // public bool progress { get; set; }
    }
}
