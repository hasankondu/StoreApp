using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface IFavoriteDAL : IRepository<Favorite>
    {
        Favorite GetByUserID(string userId);
        void RemoveFromFavorite(int favoriteId, int productId);
    }
}
