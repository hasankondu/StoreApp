using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Concrete
{
    public class CategorySubManager : ICategorySubService
    {
        private ICategorySubDAL _categorySubDAL;
        public CategorySubManager(ICategorySubDAL categorySubDAL)
        {
            _categorySubDAL = categorySubDAL;
        }
        public void Create(CategorySub entity)
        {
            _categorySubDAL.Create(entity);
        }

        public void Delete(CategorySub entity)
        {
            _categorySubDAL.Delete(entity);
        }

        public void DeleteFromCategorySub(int categorySubID, int productID)
        {
            _categorySubDAL.DeleteFromCategorySub(categorySubID, productID);
        }

        public List<CategorySub> GetAll()
        {
            return _categorySubDAL.GetAll();
        }

        public CategorySub GetById(int id)
        {
            return _categorySubDAL.GetById(id);
        }

        public CategorySub GetByIdWithCategories(int id)
        {
            return _categorySubDAL.GetByIdWithCategories(id);
        }

        public CategorySub GetByIdWithProducts(int id)
        {
            return _categorySubDAL.GetByIdWithProducts(id);
        }

        public void Update(CategorySub entity)
        {
            _categorySubDAL.Update(entity);
        }
    }
}
