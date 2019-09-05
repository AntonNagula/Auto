using AutoMapper;
using DomainCore.Models;
using InfructructureDataInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Mappers
{
    public static class Map
    {
        public static DomainCar FromRepoCarToDomainCar(this RepoCar item)
        {
            if (item == null) return null;
            return new DomainCar
            {
                Id = item.Id,
                Name = item.Name,
                CarBrand = item.CarBrand,
                Price = item.Price,
                ExtencionName = item.ExtencionName,
                Info = item.Info,
                image = item.image,
                OwnerId = item.OwnerId,
                BrandId = item.BrandId,
                // BuyCars = item.BuyCars.Select(x => x.FromRepoBuyCarToDomainBuyCar()).ToList(),
            };
        }

        public static RepoCar FromDomainCarToRepoCar(this DomainCar item)
        {
            if (item == null) return null;
            return new RepoCar
            {
                Id = item.Id,
                Name = item.Name,
                CarBrand = item.CarBrand,
                Price = item.Price,
                ExtencionName = item.ExtencionName,
                Info = item.Info,
                image = item.image,
                OwnerId = item.OwnerId,
                BrandId = item.BrandId,
                //BuyCars = item.BuyCars.Select(x => x.FromDomainBuyCarToRepoBuyCar()).ToList(),
            };
        }

        public static DomainBuyer FromRepoBuyerToDomainBuyer(this RepoBuyer item)
        {
            if (item == null) return null;
            return new DomainBuyer
            {
                Id = item.Id,
                Email = item.Email,

            };
        }

        public static RepoBuyer FromDomainBuyerToRepoBuyer(this DomainBuyer item)
        {
            if (item == null) return null;
            return new RepoBuyer
            {
                Id = item.Id,
                Email = item.Email,                
            };
        }

        public static DomainBuyCar FromRepoBuyCarToDomainBuyCar(this RepoBuyCar item)
        {
            return new DomainBuyCar
            {
                BuyerId = item.BuyerId,
                Buyer = item.Buyer.FromRepoBuyerToDomainBuyer(),
                Car = item.Car.FromRepoCarToDomainCar(),
                CarId = item.CarId
            };
        }

        public static RepoBuyCar FromDomainBuyCarToRepoBuyCar(this DomainBuyCar item)
        {
            return new RepoBuyCar
            {
                BuyerId = item.BuyerId,
                Buyer = item.Buyer.FromDomainBuyerToRepoBuyer(),
                Car = item.Car.FromDomainCarToRepoCar(),
                CarId = item.CarId
            };
        }

        public static DomainBrands FromRepoBrandToDomainBrand(this RepoBrands item)
        {
            return new DomainBrands
            {
                Id = item.Id,
                BrandName = item.BrandName,

            };
        }

        public static RepoBrands FromDomainBrandToRepoBrand(this DomainBrands item)
        {
            return new RepoBrands
            {                
                BrandName = item.BrandName,
            };
        }
    }
}
