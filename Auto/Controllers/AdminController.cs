using Auto.ModelsApp;
using DomainCore.Interfaces;
using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auto.Mappers;
namespace Auto.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IService unit;
        public AdminController(IService Unit)
        {
            unit = Unit;
        }


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

        [HttpGet]
        public ActionResult Update(int Id)
        {
            AppCar car = unit.GetCar(Id).FromDomainCarToRepoCar();
            return View(car);
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase upload, AppCar newModel)
        {
            if (upload != null)
            {
                string fileName = Path.GetFileName(upload.FileName);
                string ext = Path.GetExtension(fileName);
                upload.SaveAs(Server.MapPath("~/Files/" + newModel.Name + ext));
                newModel.ExtencionName = newModel.Name + ext;
            }

            unit.Update_Car(newModel.FromRepoCarToDomainCar());
            return View(newModel);
        }             

        public ActionResult ShowUsers_of_Car(int id = 1)
        {
            IEnumerable<AppBuyer> b = unit.GetBuyersByCarId(id).Select(x => x.FromDomainBuyerToRepoBuyer()).ToList();
            return View(b);
        }

        public ActionResult ShowCars_of_User(int id = 1)
        {
            IEnumerable<AppCar> b = unit.GetCarsBuyerId(id).Select(x => x.FromDomainCarToRepoCar()).ToList();
            return View(b);
        }

        public ActionResult ShowCar(int id)
        {
            AppCar car = unit.GetCar(id).FromDomainCarToRepoCar();
            return View(car);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var car=unit.GetCar(id).FromDomainCarToRepoCar();
            return View(car);
        }

        [HttpPost]
        public ActionResult DeleteCar(int id)
        {
            unit.Delete_Car(id);
            return View();
        }
        
        [HttpGet]
        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrand(string brand)
        {
            unit.CreateBrand(brand);
            return View();
        }
    }
}