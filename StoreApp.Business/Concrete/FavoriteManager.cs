using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private IFavoriteDAL _favoriteDAL;
        public FavoriteManager(IFavoriteDAL favoriteDAL)
        {
            _favoriteDAL = favoriteDAL;
        }

        public void AddToFavorite(string userId, int productId)
        {
            var favorite = GetFavoriteByUserID(userId);
            if (favorite != null)
            {
                var index = favorite.FavoriteItems.FindIndex(i => i.ProductID == productId);

                if (index < 0)
                {
                    favorite.FavoriteItems.Add(new FavoriteItem()
                    {
                        ProductID = productId,
                        FavoriteID = favorite.FavoriteID
                    });
                }

                _favoriteDAL.Update(favorite);
            }
        }

        public Favorite GetFavoriteByUserID(string userId)
        {
            return _favoriteDAL.GetByUserID(userId);
        }

        public void InitializeFavorite(string userId)
        {
            _favoriteDAL.Create(new Favorite()
            {
                UserID = userId
            });
        }

        public void RemoveFromFavorite(string userId, int productId)
        {
            var favorite = GetFavoriteByUserID(userId);
            if (favorite != null)
            {
                var favoriteId = favorite.FavoriteID;
                _favoriteDAL.RemoveFromFavorite(favoriteId, productId);
            }
        }
    }
}
