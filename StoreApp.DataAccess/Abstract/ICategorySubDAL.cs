using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface ICategorySubDAL : IRepository<CategorySub>
    {
        List<CategorySub> GetAll();
        CategorySub GetByIdWithProducts(int id);
        void DeleteFromCategorySub(int categorySubID, int productID);
        CategorySub GetByIdWithCategories(int id);
    }
}
