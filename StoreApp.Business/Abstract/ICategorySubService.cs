using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Abstract
{
    public interface ICategorySubService
    {
        List<CategorySub> GetAll();
        CategorySub GetByIdWithProducts(int id);
        CategorySub GetByIdWithCategories(int id);
        CategorySub GetById(int id);
        void Create(CategorySub entity);
        void Update(CategorySub entity);
        void Delete(CategorySub entity);
        void DeleteFromCategorySub(int categorySubID, int productID);
    }
}
