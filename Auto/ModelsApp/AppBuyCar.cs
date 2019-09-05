using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auto.ModelsApp
{
    public class AppBuyCar
    {
        public int CarId { get; set; }
        public AppCar Car { get; set; }

        public int BuyerId { get; set; }
        public AppBuyer Buyer { get; set; }
    }
}