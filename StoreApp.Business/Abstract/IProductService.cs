using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Abstract
{
    public interface IProductService 
    {
        Product GetByID(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategorySub(string categorysub,int page,int pageSize, string searchString);
        List<Product> GetNewProducts();

        List<Product> GetProducts(string userId);



        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategorySub(string categorysub,string searchString);
        Product GetByIDWithCategorySubs(int id);
        void Update(Product entity, int[] categorySubIDs);
    }
}
