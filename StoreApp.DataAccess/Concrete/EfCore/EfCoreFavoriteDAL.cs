using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreFavoriteDAL : EfCoreGenericRepository<Favorite, StoreContext>, IFavoriteDAL
    {
        public override void Update(Favorite entity)
        {
            using (var context = new StoreContext())
            {
                context.Favorites.Update(entity);
                context.SaveChanges();
            }
        }

        public Favorite GetByUserID(string userId)
        {
            using (var context = new StoreContext())
            {
                return context.Favorites
                    .Include(i => i.FavoriteItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserID == userId);
            }
        }

        public void RemoveFromFavorite(int favoriteId, int productId)
        {
            using (var context = new StoreContext())
            {
                var cmd = @"delete from FavoriteItem where FavoriteID=@p0 And ProductID=@p1";

                context.Database.ExecuteSqlRaw(cmd, favoriteId, productId);
            }
        }
    }
}
