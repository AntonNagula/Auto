using InfrustructureData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureData.Initialization
{
    public interface IProvider
    {
        IList<Brands> GetBrands();
        IList<Buyer> GetBuyers();
        IList<Car> GetCars();
        IList<BuyCar> GetBuyCars();
    }
}
