using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDAL : EfCoreGenericRepository<Product, StoreContext>, IProductDAL
    {
        public Product GetByIDWithCategorySubs(int id)
        {
            using (var context = new StoreContext())
            {
                return context.Products
                    .Where(i => i.ProductID == id)
                    .Include(i => i.ProductCategorySubs)
                    .ThenInclude(i => i.CategorySub)
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategorySub(string categorysub,string searchString)
        {
            using (var context = new StoreContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(categorysub))
                {
                    products = products
                        .Include(i => i.ProductCategorySubs)
                        .ThenInclude(i => i.CategorySub)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategorySubs.Any(b => b.CategorySub.CategorySubName.ToLower() == categorysub.ToLower()));

                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    products = products
                        .Include(i => i.ProductCategorySubs)
                        .ThenInclude(i => i.CategorySub)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductName.ToLower().Contains(searchString.ToLower()));

                }
                return products.Count();
            }
        }

        public List<Product> GetNewProducts()
        {
            using (var context = new StoreContext())
            {
                List<Product> list = (from p in context.Products where p.UnitsInStock >= 0 orderby p.DisplayDate descending select p).Take(4).ToList();
                return (List<Product>)list;
            }
        }



        public Product GetProductDetails(int id)
        {
            using (var context = new StoreContext())
            {
                return context.Products
                    .Where(i => i.ProductID == id)
                    .Include(i => i.ProductCategorySubs)
                    .ThenInclude(i => i.CategorySub)
                    .FirstOrDefault();

            }
        }

        public List<Product> GetProducts(string userId)
        {
            using (var context = new StoreContext())
            {
                var products = context.Products
                    .AsQueryable();


                if (!string.IsNullOrEmpty(userId))
                {
                    products = products.Where(i => i.UserId == userId);
                }

                return products.ToList();
            }
        }

        public List<Product> GetProductsByCategorySub(string categorysub, int page, int pageSize, string searchString)
        {
            using (var context = new StoreContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(categorysub))
                {
                    products = products
                        .Include(i => i.ProductCategorySubs)
                        .ThenInclude(i => i.CategorySub)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategorySubs.Any(b => b.CategorySub.CategorySubName.ToLower() == categorysub.ToLower()));

                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    products = products
                       .Include(i => i.ProductCategorySubs)
                       .ThenInclude(i => i.CategorySub)
                       .ThenInclude(i => i.Category)
                       .Where(i => i.ProductName.ToLower().Contains(searchString.ToLower()));
                }


                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void Update(Product entity, int[] categorySubIDs)
        {
            using (var context = new StoreContext())
            {
                var product = context.Products
                    .Include(i=>i.ProductCategorySubs)
                    .FirstOrDefault(i => i.ProductID == entity.ProductID);

                if (product!=null)
                {
                    product.ProductName = entity.ProductName;
                    product.Description = entity.Description;
                    product.ImageUrl = entity.ImageUrl;
                    product.UnitPrice = entity.UnitPrice;

                    product.ProductCategorySubs = categorySubIDs.Select(i => new ProductCategorySub()
                    {
                        CategorySubID=i,
                        ProductID = entity.ProductID
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}