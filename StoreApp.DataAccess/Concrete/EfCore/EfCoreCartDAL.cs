using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCartDAL : EfCoreGenericRepository<Cart, StoreContext>, ICartDAL
    {
        public override void Update(Cart entity)
        {
            using (var context = new StoreContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }

        public Cart GetByUserID(string userId)
        {
            using (var context = new StoreContext())
            {
                return context.Carts
                    .Include(i => i.CartItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserID == userId);
            }
        }

        public void RemoveFromCart(int cartId, int productId)
        {
            using (var context = new StoreContext())
            {
                var cmd = @"delete from CartItem where CartID=@p0 And ProductID=@p1";



                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public void ClearCart(int cartId)
        {
            using (var context = new StoreContext())
            {
                var cmd = @"delete from CartItem where CartID=@p0 ";


                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }
    }
}
