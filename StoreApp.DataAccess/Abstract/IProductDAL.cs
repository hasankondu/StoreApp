using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface IProductDAL : IRepository<Product>
    {
        List<Product> GetProductsByCategorySub(string categorysub,int page,int pageSize, string searchString);
        Product GetProductDetails(int id);
        List<Product> GetNewProducts();
        int GetCountByCategorySub(string categorysub,string searchString);
        Product GetByIDWithCategorySubs(int id);
        void Update(Product entity, int[] categorySubIDs);
        List<Product> GetProducts(string userId);
    }
}
