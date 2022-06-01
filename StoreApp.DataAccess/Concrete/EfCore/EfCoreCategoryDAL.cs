using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDAL : EfCoreGenericRepository<Category, StoreContext>, ICategoryDAL
    {
        public List<Category> GetAll()
        {
            using (var context = new StoreContext())
            {
                return context.Categories
                    .Include(i => i.CategorySubs)
                    .ToList();


            }
        }
    }
}
