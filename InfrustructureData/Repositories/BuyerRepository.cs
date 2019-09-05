using InfructructureDataInterfaces.Models;
using InfructructureDataInterfaces.Repositories;
using InfrustructureData.Data;
using InfrustructureData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using InfrustructureData.Mappers;
using Microsoft.EntityFrameworkCore;

namespace InfrustructureData.Repositories
{
    public class BuyerRepository : IRepositories<RepoBuyer>
    {
        private AutoContext db;

        public BuyerRepository(AutoContext db)
        {
            this.db = db;
        }
        public void Create(RepoBuyer item)
        {
            db.Buyers.Add(item.FromRepoBuyerToBuyer());
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Buyer buyer = db.Buyers.Find(id);
            db.Buyers.Remove(buyer);
            db.SaveChanges();
        }

        public RepoBuyer Get(int id)
        {
            RepoBuyer obj = db.Buyers.Find(id).FromBuyerToRepoBuyer();
           
            return db.Buyers.Find(id).FromBuyerToRepoBuyer();
        }

        //public RepoBuyer Get(string email)
        //{

        //    List<Buyer> obj = db.Buyers.Where(x=>x.Email==email).ToList();
        //    Buyer buyer = new Buyer();
        //    if (obj.Count()==0)
        //    {
        //        buyer = new Buyer { Email = email };
        //        db.Buyers.Add(buyer);
        //        db.SaveChanges();
        //        buyer = db.Buyers.Where(x => x.Email == email).ToList()[0];
        //    }
        //    else
        //    {
        //        buyer = obj[0];
        //    }            
        //    return buyer.FromBuyerToRepoBuyer();
        //}

        public IEnumerable<RepoBuyer> GetAll()
        {
            return db.Buyers.Select(x=>x.FromBuyerToRepoBuyer()).ToList();
        }

        public void Update(RepoBuyer item)
        {
            throw new NotImplementedException();
        }
    }
}
