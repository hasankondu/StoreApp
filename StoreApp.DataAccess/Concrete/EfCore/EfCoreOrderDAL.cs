using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDAL : EfCoreGenericRepository<Order, StoreContext>, IOrderDAL
    {
        public List<Order> GetOrders(string userID)
        {
            using (var context = new StoreContext())
            {
                var orders = context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Product)
                    .AsQueryable();


                if (!string.IsNullOrEmpty(userID))
                {
                    orders = orders.Where(i => i.UserId == userID);
                }

                return orders.ToList();
            }
        }
    }
}
