using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreAdvertisedDAL : EfCoreGenericRepository<Advertised, StoreContext>, IAdvertisedDAL
    {
        public List<Advertised> GetAll()
        {
            using (var context = new StoreContext())
            {
                return context.Advertiseds
                    .Include(i => i.Product)
                    .ToList();

            }
        }
    }
}
