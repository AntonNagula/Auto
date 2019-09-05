using DomainCore.Interfaces;
using DomainCore.Models;
using InfructructureDataInterfaces.Repositories;
using DomainService.Mappers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DomainService.Service
{
    public class Service : IService
    {        
        public readonly IUnitOfWork _Repositories;

        public void CreateBrand(string brandName)
        {
            DomainBrands brand = new DomainBrands {  BrandName=brandName};
            _Repositories.Brands.Create(brand.FromDomainBrandToRepoBrand());
        }

        List<DomainBrands> Brands;
        List<DomainCar> Cars;
        List<DomainBuyCar> BuyCars;
        List<DomainBuyer> Buyers;

        public Service(IUnitOfWork Repository)
        {
            _Repositories = Repository;
            Cars = Repository.Cars.GetAll().Select(x=>x.FromRepoCarToDomainCar()).ToList();
            BuyCars = Repository.BuyCars.GetAll().Select(x => x.FromRepoBuyCarToDomainBuyCar()).ToList();
            Buyers = Repository.Buyers.GetAll().Select(x => x.FromRepoBuyerToDomainBuyer()).ToList();
            Brands = Repository.Brands.GetAll().Select(x => x.FromRepoBrandToDomainBrand()).ToList();
        }       
        //
        public IEnumerable<DomainBrands> GetAllBrands()
        {
           
            return Brands;
        }
        //
        public IEnumerable<DomainCar> GetAllCars(int i,int  size,out int Total)
        {            
            List<DomainCar> cars = Cars.ToList();
            Total = cars.Count;
            if (i * size > Total)
                i = Total / size+1;
            List<DomainCar> result = Cars.Skip((i - 1) * size).Take(size).ToList();
            return result;
        }

        //
        public IEnumerable<DomainCar> GetAllCars(int i, int size, string brand,out int Total)
        {
            List<DomainCar> currentcars;
            if (brand != "Все")
                currentcars = Cars.Where(x => x.CarBrand == brand).ToList();
            else
                currentcars = Cars;
            Total = currentcars.Count;
            if (Total < size)
                size = Total;
            else if (i * size > Total)
                i = Total / size + 1;
            List<DomainCar> result = currentcars.Skip((i - 1) * size).Take(size).ToList();
            return result;
        }

        //
        public IEnumerable<DomainCar> GetAllCars()
        {
            return Cars;
        }

        //
        public IEnumerable<DomainCar> GetCarsBuyerId(int id)
        {            
            List<DomainCar> domainCars = new List<DomainCar>();
            foreach(DomainBuyCar c in BuyCars)
            {
                if(c.BuyerId==id)
                {
                    domainCars.Add(c.Car);
                }
            }
            return domainCars;
        }

        //
        public IEnumerable<DomainCar> GetCarsByOwnerId(int id)
        {            
            return Cars.Where(x => x.OwnerId == id).ToList();
        }
               

        //
        public DomainCar GetCar(int id)
        {
            return Cars.FirstOrDefault(x=>x.Id==id);
        }
        //
        public void Create_Car(DomainCar item)
        {
            if (item.BrandId == 0)
            {
                int size = 1 + GetAllBrands().ToList().Count;
                item.BrandId = size;
                DomainBrands brand = new DomainBrands { BrandName = item.CarBrand };
                Brands.Add(brand);
                _Repositories.Brands.Create(brand.FromDomainBrandToRepoBrand());
            }
            else
            {
                item.CarBrand = Brands.FirstOrDefault(x => x.Id == item.BrandId).BrandName;
            }
            Cars.Add(item);
            _Repositories.Cars.Create(item.FromDomainCarToRepoCar());
        }


        public void Update_Car(DomainCar item)
        {
            _Repositories.Cars.Update(item.FromDomainCarToRepoCar());
        }
        public void Delete_Car(int id)
        {
            //List<DomainBuyCar> list = _Repositories.BuyCars.GetById(id).Select(x=>x.FromRepoBuyCarToDomainBuyCar()).ToList();
            //if (list.Count == 0)
            //    _Repositories.Cars.Delete(id);
            //else
            //{
            //    DomainCar car = _Repositories.Cars.Get(id).FromRepoCarToDomainCar();                     
            //    _Repositories.Cars.Update(car.FromDomainCarToRepoCar());
            //}
        }




        //
        public bool Buy(DomainBuyCar item)
        {            
            DomainCar car=Cars.FirstOrDefault(x=>x.Id==item.CarId);
            item.Car = car;
            item.Buyer = Buyers.FirstOrDefault(x=>x.Id==item.BuyerId);
            BuyCars.Add(item);
            _Repositories.Cars.Update(car.FromDomainCarToRepoCar());
            _Repositories.BuyCars.Create(item.FromDomainBuyCarToRepoBuyCar());
            return true;
        }




        //
        public IEnumerable<DomainBuyer> GetAllBuyers()
        {
            return Buyers;
        }

        //       
        public IEnumerable<DomainBuyer> GetBuyersByCarId(int id)
        {
            //return _Repositories.Buyers.GetById(id).Select(x => x.FromRepoBuyerToDomainBuyer()).ToList();

            List<DomainBuyer> domainBuyers = new List<DomainBuyer>();
            foreach (DomainBuyCar c in BuyCars)
            {
                if (c.CarId == id)
                {
                    domainBuyers.Add(c.Buyer);
                }
            }
            return domainBuyers;
        }

        //
        public DomainBuyer GetBuyer(int id)
        {
            return Buyers.FirstOrDefault(x=>x.Id==id);
        }

        //
        public DomainBuyer GetBuyer(string email)
        {
            DomainBuyer model=Buyers.FirstOrDefault(x => x.Email == email);
            if(model==null)
            {
                model = new DomainBuyer { Email = email };
                Buyers.Add(model);
                _Repositories.Buyers.Create(model.FromDomainBuyerToRepoBuyer());
               
            }
            return model;
        }
        public void Create_Buyer(DomainBuyer item)
        {
            _Repositories.Buyers.Create(item.FromDomainBuyerToRepoBuyer());
        }
        public void Update_Buyer(DomainBuyer item)
        {

        }
        public void Delete_Buyer(int id)
        {
            _Repositories.Buyers.Delete(id);
        }       
    }
}
