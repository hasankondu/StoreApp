using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface ICategoryDAL : IRepository<Category>
    {
        List<Category> GetAll();
    }
}
