using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfructructureDataInterfaces.Models
{
    public class RepoBuyCar
    {
        public int CarId { get; set; }
        public RepoCar Car { get; set; }

        public int BuyerId { get; set; }
        public RepoBuyer Buyer { get; set; }

        //public bool progress { get; set; }
    }
}
