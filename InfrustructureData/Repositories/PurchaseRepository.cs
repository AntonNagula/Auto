using InfructructureDataInterfaces.Models;
using InfructructureDataInterfaces.Repositories;
using InfrustructureData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using InfrustructureData.Mappers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InfrustructureData.Repositories
{
    public class PurchaseRepository : IRepositories<RepoBuyCar>
    {
        private AutoContext db;

        public PurchaseRepository(AutoContext db)
        {
            this.db = db;
        }
        public void Create(RepoBuyCar item)
        {
            db.BuyCars.Add(item.FromRepoBuyCarToBuyCar());
            db.SaveChanges();
        }

        public IEnumerable<RepoBuyCar> GetAll()
        {
            return db.BuyCars.Include(x=>x.Car).Include(x=>x.Buyer).Select(x => x.FromBuyCarToRepoBuyCar()).ToList();
        }

        RepoBuyCar IRepositories<RepoBuyCar>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RepoBuyCar item)
        {
            throw new NotImplementedException();
        }        

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
