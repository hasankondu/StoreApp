using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface IOrderDAL : IRepository<Order>
    {
        List<Order> GetOrders(string userID);
    }
}
