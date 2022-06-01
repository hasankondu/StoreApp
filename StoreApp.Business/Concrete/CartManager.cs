using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDAL _cartDAL;
        public CartManager(ICartDAL cartDAL)
        {
            _cartDAL = cartDAL;
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserID(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(i => i.ProductID == productId);

                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductID = productId,
                        Quantity = quantity,
                        CartID = cart.CartID
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartDAL.Update(cart);
            }
        }

        public void ClearCart(int cartId)
        {
            _cartDAL.ClearCart(cartId);
        }

        public Cart GetCartByUserID(string userId)
        {
            return _cartDAL.GetByUserID(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartDAL.Create(new Cart()
            {
                UserID = userId
            });
        }

        public void RemoveFromCart(string userId, int productId)
        {
            var cart = GetCartByUserID(userId);
            if (cart != null)
            {
                var cartId = cart.CartID;
                _cartDAL.RemoveFromCart(cartId, productId);
            }
        }
    }
}
