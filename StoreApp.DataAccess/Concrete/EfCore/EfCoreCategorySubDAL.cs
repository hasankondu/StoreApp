using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCategorySubDAL : EfCoreGenericRepository<CategorySub, StoreContext>, ICategorySubDAL
    {
        public void DeleteFromCategorySub(int categorySubID, int productID)
        {
            using (var context = new StoreContext())
            {
                var cmd = @"delete from ProductCategorySub where ProductID=@p0 And CategorySubID=@p1";
                context.Database.ExecuteSqlRaw(cmd,productID,categorySubID);
            }
        }
        public List<CategorySub> GetAll()
        {
            using (var context = new StoreContext())
            {
                return context.CategorySubs
                    .Include(i => i.Category)
                    .ToList();


            }
        }

        public CategorySub GetByIdWithCategories(int id)
        {
            using (var context = new StoreContext())
            {
                return context.CategorySubs
                    .Where(i => i.CategorySubID == id)
                    .Include(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public CategorySub GetByIdWithProducts(int id)
        {
            using (var context = new StoreContext())
            {
                return context.CategorySubs
                    .Where(i => i.CategorySubID == id)
                    .Include(i => i.Category)
                    .Include(i => i.ProductCategorySubs)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }
    }
}
