using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);

        List<Order> GetOrders(string userID);
    }
}
