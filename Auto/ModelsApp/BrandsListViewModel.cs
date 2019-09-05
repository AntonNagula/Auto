using System.Collections.Generic;
using System.Web.Mvc;

namespace Auto.ModelsApp
{
    public class BrandsListViewModel
    {
        public IEnumerable<AppCar> Cars { get; set; }
        public SelectList Brands { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}