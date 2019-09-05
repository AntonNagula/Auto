using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auto.ModelsApp
{
    public class IndexViewModel
    {
        public IEnumerable<AppCar> Cars { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}