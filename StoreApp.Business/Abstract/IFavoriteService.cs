using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Abstract
{
    public interface IFavoriteService
    {
        void InitializeFavorite(string userId);

        Favorite GetFavoriteByUserID(string userId);

        void AddToFavorite(string userId, int productId);
        void RemoveFromFavorite(string userId, int productId);
    }
}
