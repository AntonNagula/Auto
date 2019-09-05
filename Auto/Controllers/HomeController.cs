using Auto.Filters;
using Auto.Mappers;
using Auto.ModelsApp;
using DomainCore.Interfaces;
using DomainCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auto.Controllers
{
    [WayEnter]
    public class HomeController : Controller
    {        
        IService unit;
        public HomeController(IService Unit)
        {
            unit = Unit;
        }
        //public ActionResult Index(int i = 1)
        //{
        //    int Total,size=6;
        //    List<AppCar> b = unit.GetAllCars(i,size,out Total).Select(x => x.FromDomainCarToRepoCar()).ToList();             
        //    PageInfo page = new PageInfo { PageSize = size, PageNumber = i, TotalItems = Total};
        //    IndexViewModel index = new IndexViewModel { PageInfo = page, Cars = b };
        //    return View(index);
        //}

        public ActionResult Index(int i = 1, string brand = "Все")
        {
            int Total, size = 6;
            List<AppCar> b = unit.GetAllCars(i, size, brand, out Total).Select(x => x.FromDomainCarToRepoCar()).ToList();
            PageInfo page = new PageInfo { PageSize = size, PageNumber = i, TotalItems = Total };
            IndexViewModel index = new IndexViewModel { PageInfo = page, Cars = b };
            List<string> CarBrands = unit.GetAllBrands().Select(x => x.FromAppBrandToBrand()).ToList();
            CarBrands.Insert(0, "Все");
            BrandsListViewModel brands = new BrandsListViewModel { PageInfo = page, Cars = b, Brands = new SelectList(CarBrands) };
            return View(brands);
        }

        public ActionResult ShowCar(int id)
        {
            AppCar car = unit.GetCar(id).FromDomainCarToRepoCar();
            return View(car);
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

    }
}