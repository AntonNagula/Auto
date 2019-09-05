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
    public class BrandRepository : IRepositories<RepoBrands>
    {
        private AutoContext db;

        public BrandRepository(AutoContext db)
        {
            this.db = db;
        }
        public void Create(RepoBrands item)
        {
            db.Brands.Add(item.FromRepoBrandsToBrands());
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Brands brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
        }

        public RepoBrands Get(int id)
        {
            RepoBrands obj = db.Brands.Find(id).FromBrandsToRepoBrands();

            return db.Brands.Find(id).FromBrandsToRepoBrands();
        }

        public IEnumerable<RepoBrands> GetAll()
        {
            return db.Brands.Select(x => x.FromBrandsToRepoBrands()).ToList();
        }

        public void Update(RepoBrands item)
        {
            throw new NotImplementedException();
        }
    }
}
