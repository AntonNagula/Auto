using AutoMapper;
using InfructructureDataInterfaces.Models;
using InfrustructureData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureData.Mappers
{
    public static class Convert
    {
        //public static Car FromRepoCarToCar(this RepoCar item)
        //{
        //    return new Car
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        CarBrand = item.CarBrand,
        //        Price = item.Price,
        //        ExtencionName = item.ExtencionName,
        //        Info = item.Info,
        //        Count_Of_Unit = item.Count_Of_Unit,
        //        image = item.image,
        //        BuyCars = item.BuyCars.Select(x => x.FromRepoBuyCarToBuyCar()).ToList(),
        //    };
        //}        

        //public static RepoCar FromCarToRepoCar(this Car item)
        //{
        //    return new RepoCar
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        CarBrand = item.CarBrand,
        //        Price = item.Price,
        //        ExtencionName = item.ExtencionName,
        //        Info = item.Info,
        //        Count_Of_Unit=item.Count_Of_Unit,
        //        image=item.image,
        //        //BuyCars = item.BuyCars.Select(x=>x.FromBuyCarToRepoBuyCar()).ToList(),
        //    };
        //}

        //public static Buyer FromRepoBuyerToBuyer(this RepoBuyer item)
        //{
        //    return new Buyer
        //    {
        //        Id = item.Id,
        //        Email= item.Email,
        //        Password=item.Password,
        //        BuyCars = item.BuyCars.Select(x => x.FromRepoBuyCarToBuyCar()).ToList()
        //    };
        //}

        //public static RepoBuyer FromBuyerToRepoBuyer(this Buyer item)
        //{
        //    return new RepoBuyer
        //    {
        //        Id = item.Id,
        //        Email = item.Email,
        //        Password = item.Password,
        //        //BuyCars=item.BuyCars.Select(x=>x.FromBuyCarToRepoBuyCar()).ToList() 
        //    };
        //}


        public static BuyCar FromRepoBuyCarToBuyCar(this RepoBuyCar item)
        {
            return new BuyCar
            {
                BuyerId = item.BuyerId,
                Buyer = item.Buyer.FromRepoBuyerToBuyer(),
                Car = item.Car.FromRepoCarToCar(),
                CarId = item.CarId
            };
        }

        public static RepoBuyCar FromBuyCarToRepoBuyCar(this BuyCar item)
        {
            return new RepoBuyCar
            {
                BuyerId = item.BuyerId,
                Buyer = item.Buyer.FromBuyerToRepoBuyer(),
                Car = item.Car.FromCarToRepoCar(),
                CarId = item.CarId
            };
        }

        public static RepoBrands FromBrandsToRepoBrands(this Brands item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Brands, RepoBrands>()
            .ForMember(x => x.Cars, _ => _.Ignore()));
            return Mapper.Map<Brands, RepoBrands>(item);
        }

        public static Brands FromRepoBrandsToBrands(this RepoBrands item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RepoBrands, Brands>()
            .ForMember(x => x.Cars, _ => _.Ignore()));
            return Mapper.Map<RepoBrands, Brands>(item);
        }


        public static Car FromRepoCarToCar(this RepoCar item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RepoCar, Car>()
            .ForMember(x => x.BuyCars, _ => _.Ignore()));
            return Mapper.Map<RepoCar, Car>(item);
        }

        public static RepoCar FromCarToRepoCar(this Car item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Car, RepoCar>()
            .ForMember(x => x.BuyCars, _ => _.Ignore()));
            return Mapper.Map<Car, RepoCar>(item);
        }


        public static Buyer FromRepoBuyerToBuyer(this RepoBuyer item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RepoBuyer, Buyer>()
            .ForMember(x => x.BuyCars, _ => _.Ignore())
            .ForMember(x=>x.Cars,x=>x.Ignore()));
            return Mapper.Map<RepoBuyer, Buyer>(item);
        }

        public static RepoBuyer FromBuyerToRepoBuyer(this Buyer item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Buyer, RepoBuyer>()
            .ForMember(x => x.BuyCars, _ => _.Ignore()));
            return Mapper.Map<Buyer, RepoBuyer>(item);
        }

        //public static BuyCar FromRepoBuyCarToBuyCar(this RepoBuyCar item)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<RepoBuyCar, BuyCar>());
        //    return Mapper.Map<RepoBuyCar, BuyCar>(item);
        //}

        //public static RepoBuyCar FromBuyCarToRepoBuyCar(this BuyCar item)
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<BuyCar, RepoBuyCar>()); 
        //    return Mapper.Map<BuyCar, RepoBuyCar>(item);
        //}
    }
}
