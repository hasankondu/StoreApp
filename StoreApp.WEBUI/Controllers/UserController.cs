using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.Entities;
using StoreApp.WEBUI.Identity;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IProductService _productservice;
        private ICategorySubService _categorySubService;
        private ICategoryService _categoryService;
        private UserManager<ApplicationUser> _userManager;


        public UserController(UserManager<ApplicationUser> userManager,IProductService productservice, ICategorySubService categorySubService, ICategoryService categoryService)
        {
            _productservice = productservice;
            _categorySubService = categorySubService;
            _categoryService = categoryService;
            _userManager = userManager;
        }
        //public IActionResult ProductList()
        //{
        //    return View(new ProductListModel()
        //    {
        //        Products = _productservice.GetAll()
        //    });
        //}
        
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                var entity = new Product()
                {
                    ProductName = model.ProductName,
                    Description = model.Description,
                    UnitPrice = model.UnitPrice,
                    DisplayDate = DateTime.Now,
                    UserId = userId
                };

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", (file.FileName));
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }


                _productservice.Create(entity);

                return RedirectToAction("MyProducts");


            }

            return View(model);


        }


        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productservice.GetByIDWithCategorySubs((int)id);


            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                UnitPrice = entity.UnitPrice,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
                Categories = _categoryService.GetAll(),
                SelectedCategorySubs = entity.ProductCategorySubs.Select(i => i.CategorySub).ToList(),

            };

            ViewBag.CategorySubs = _categorySubService.GetAll();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel model, int[] categorySubIDs, IFormFile file)
        {
            if (ModelState.IsValid)
            {


                var entity = _productservice.GetByID(model.ProductID);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.ProductName = model.ProductName;
                entity.Description = model.Description;
                entity.UnitPrice = model.UnitPrice;

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", (file.FileName));
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                _productservice.Update(entity, categorySubIDs);

                return RedirectToAction("MyProducts");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productID)
        {
            var entity = _productservice.GetByID(productID);
            if (entity != null)
            {
                _productservice.Delete(entity);
            }
            return RedirectToAction("MyProducts");
        }

        public JsonResult BringCategorySubs(int id)
        {
            var model = new ProductModel()
            {
                SelectedCategoryWithCategorySubs = _categorySubService.GetAll()
            };
            return Json(model);
        }

        public IActionResult MyProducts()
        {
            var products = _productservice.GetProducts(_userManager.GetUserId(User));

            var productListModel = new List<ProductModel>();

            ProductModel productModel;

            foreach (var product in products)
            {
                productModel = new ProductModel();
                productModel.ProductID = product.ProductID;
                productModel.ProductName = product.ProductName;
                productModel.ImageUrl = product.ImageUrl;
                productModel.DisplayDate = product.DisplayDate;
                productModel.Description = product.Description;
                productModel.UnitPrice = product.UnitPrice;
                productModel.UnitsInOrder = product.UnitsInOrder;
                productModel.UnitsInStock = product.UnitsInStock;

                productListModel.Add(productModel);

            }


            return View(productListModel);
        }





    }
}
