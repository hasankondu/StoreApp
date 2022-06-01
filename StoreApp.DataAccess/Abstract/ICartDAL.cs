using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface ICartDAL : IRepository<Cart>
    {
        Cart GetByUserID(string userId);
        void RemoveFromCart(int cartId, int productId);
        void ClearCart(int cartId);
    }
}
