using Auto.ModelsApp;
using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auto.Mappers
{
    public static class Mapping
    {
        public static DomainBuyCar FromAppCarToDomainBuyCar(this AppBuyCar item)
        {
            return new DomainBuyCar
            {
                 CarId=item.CarId,
                 BuyerId=item.BuyerId
            };
        }

        public static DomainCar FromRepoCarToDomainCar(this AppCar item)
        {
            return new DomainCar
            {
                Id = item.Id,
                Name = item.Name,
                CarBrand = item.CarBrand,
                Price = item.Price,
                ExtencionName = item.ExtencionName,
                Info = item.Info,
                image = item.image,
                OwnerId=item.OwnerId,
                BrandId=item.BrandId, 
            };
        }

        public static AppCar FromDomainCarToRepoCar(this DomainCar item)
        {
            return new AppCar
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
            };
        }

        public static DomainBuyer FromRepoBuyerToDomainBuyer(this AppBuyer item)
        {
            return new DomainBuyer
            {
                Id = item.Id,
                Email = item.Email,

            };
        }

        public static AppBuyer FromDomainBuyerToRepoBuyer(this DomainBuyer item)
        {
            return new AppBuyer
            {
                Id = item.Id,
                Email = item.Email,
            };
        }

        public static string FromAppBrandToBrand(this DomainBrands item)
        {
            return item.BrandName;
        }

        public static DomainBrands FromAppCarBrandToDomainBrand(this AppCarBrand item)
        {
            return new DomainBrands
            {
                Id = item.Id,
                BrandName =item.BrandName,

            };
        }

        public static AppCarBrand FromDomainBrandsToAppCarBrand(this DomainBrands item)
        {
            return new AppCarBrand
            {
                Id = item.Id,
                BrandName = item.BrandName,
            };
        }
    }
}