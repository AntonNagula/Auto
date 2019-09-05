using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Interfaces
{
    public interface IService
    {
        IEnumerable<DomainCar> GetAllCars();
        IEnumerable<DomainCar> GetAllCars(int i,int size,out int Total);
        IEnumerable<DomainCar> GetAllCars(int i, int size, string brand,out int Total);
        IEnumerable<DomainCar> GetCarsBuyerId(int id);
        IEnumerable<DomainCar> GetCarsByOwnerId(int id);
        DomainCar GetCar(int id);
        void Create_Car(DomainCar item);
        void Update_Car(DomainCar item);
        void Delete_Car(int id);

        IEnumerable<DomainBuyer> GetAllBuyers();
        IEnumerable<DomainBuyer> GetBuyersByCarId(int id);
        DomainBuyer GetBuyer(int id);
        DomainBuyer GetBuyer(string email);
        void Create_Buyer(DomainBuyer item);
        void Update_Buyer(DomainBuyer item);
        void Delete_Buyer(int id);


        bool Buy(DomainBuyCar item);

        void CreateBrand(string brandName);
        IEnumerable<DomainBrands> GetAllBrands();
    }
}
