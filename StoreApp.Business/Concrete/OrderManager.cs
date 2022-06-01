using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDAL _orderDAL;
        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public void Create(Order entity)
        {
            _orderDAL.Create(entity);
        }

        public List<Order> GetOrders(string userID)
        {
            return _orderDAL.GetOrders(userID);
        }
    }
}
