using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);

        Cart GetCartByUserID(string userId);

        void AddToCart(string userId, int productId, int quantity);
        void RemoveFromCart(string userId, int productId);
        void ClearCart(int cartId);
    }
}
