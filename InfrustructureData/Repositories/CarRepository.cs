using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfructructureDataInterfaces.Repositories;
using InfructructureDataInterfaces.Models;
using InfrustructureData.Data;
using InfrustructureData.Mappers;
using Microsoft.EntityFrameworkCore;
using InfrustructureData.DataModels;

namespace InfrustructureData.Repositories
{
    public class CarRepository : IRepositories<RepoCar>
    {
        private AutoContext db;

        public CarRepository(AutoContext db)
        {
            this.db = db;
        }
        public void Create(RepoCar item)
        {
            db.Cars.Add(item.FromRepoCarToCar());
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();            
        }

        public RepoCar Get(int id)
        {            
            return db.Cars.Find(id).FromCarToRepoCar();
        }

        public IEnumerable<RepoCar> GetAll()
        {
            return db.Cars.Select(x=>x.FromCarToRepoCar()).ToList();
        }

        public void Update(RepoCar item)
        {            
            Car car=db.Cars.Find(item.Id);         
            car.CarBrand = item.CarBrand;
            car.Name = item.Name;
            car.Price = item.Price;
            car.Info = item.Info;
            if(item.ExtencionName!=null)
            car.ExtencionName = item.ExtencionName;
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
