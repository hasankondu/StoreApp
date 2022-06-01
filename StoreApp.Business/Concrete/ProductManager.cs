using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.Concrete.EfCore;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        
        private IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        

        public void Create(Product entity)
        {
                _productDAL.Create(entity);
        }
        public void Update(Product entity, int[] categorySubIDs)
        {
            _productDAL.Update(entity, categorySubIDs);
        }

        public void Delete(Product entity)
        {
            _productDAL.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public Product GetByID(int id)
        {
            return _productDAL.GetById(id);
        }

        public int GetCountByCategorySub(string categorysub,string searchString)
        {
            return _productDAL.GetCountByCategorySub(categorysub, searchString);
        }

        public List<Product> GetNewProducts()
        {
            return _productDAL.GetNewProducts();
        }

        

        public Product GetProductDetails(int id)
        {
            return _productDAL.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategorySub(string categorysub,int page,int pageSize, string searchString)
        {
            return _productDAL.GetProductsByCategorySub(categorysub,page, pageSize,searchString);
        }

        public void Update(Product entity)
        {
            _productDAL.Update(entity);
        }


        public Product GetByIDWithCategorySubs(int id)
        {
            return _productDAL.GetByIDWithCategorySubs(id);
        }

        public List<Product> GetProducts(string userId)
        {
            return _productDAL.GetProducts(userId);
        }
    }
}
