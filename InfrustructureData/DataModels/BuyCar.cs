using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureData.DataModels
{
    public class BuyCar
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }
    }
}
