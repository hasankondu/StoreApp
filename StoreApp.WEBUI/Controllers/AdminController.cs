using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.Entities;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ICategoryService _categoryService;
        private ICategorySubService _categorySubService;
        private IProductService _productService;
        private IAdvertisedService _advertisedService;

        public AdminController(IAdvertisedService advertisedService,IProductService productService,ICategoryService categoryService, ICategorySubService categorySubService)
        {
            _categoryService = categoryService;
            _categorySubService = categorySubService;
            _productService = productService;
            _advertisedService = advertisedService;
        }


        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new CategoryModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryModel model, IFormFile file)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName
            };

            if (file != null)
            {
                entity.ImageUrl = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\categories", (file.FileName));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _categoryService.Create(entity);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {

            var entity = _categoryService.GetById(id);


            return View(new CategoryModel()
            {

                CategoryID = entity.CategoryID,
                CategoryName = entity.CategoryName,
                ImageUrl = entity.ImageUrl

            }) ;
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryModel model, IFormFile file)
        {
            var entity = _categoryService.GetById(model.CategoryID);
            if (entity == null)
            {
                return NotFound();
            }
            entity.CategoryName = model.CategoryName;

            if (file != null)
            {
                entity.ImageUrl = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\categories", (file.FileName));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }


            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }



        [HttpPost]
        public IActionResult DeleteCategory(int categoryID)
        {
            var entity = _categoryService.GetById(categoryID);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }






        public IActionResult CategorySubList()
        {
            return View(new CategorySubListModel() { 
            CategorySubs=_categorySubService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateCategorySub()
        {
            return View(new CategorySubModel() { 
            Categories = _categoryService.GetAll()
            });;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorySub(CategorySubModel model, IFormFile file)
        {
            
            var entity = new CategorySub()
            {
                CategorySubName = model.CategorySubName,
                CategoryID = model.CategoryID
            };

            if (file != null)
            {
                entity.ImageUrl = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\categorysubs", (file.FileName));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _categorySubService.Create(entity);
            return RedirectToAction("CategorySubList");
        }
        [HttpGet]
        public IActionResult EditCategorySub(int id)
        {
            var entity = _categorySubService.GetByIdWithProducts(id);
            


            return View(new CategorySubModel()
            {

                CategorySubID = entity.CategorySubID,
                CategorySubName = entity.CategorySubName,
                ImageUrl = entity.ImageUrl,
                CategoryID=entity.CategoryID,
                Products = entity.ProductCategorySubs.Select(p=>p.Product).ToList(),
                Categories=_categoryService.GetAll()

            });
        }

        [HttpPost]
        public async Task<IActionResult> EditCategorySub(CategorySubModel model, IFormFile file)
        {
            var entity = _categorySubService.GetById(model.CategorySubID);
            if (entity == null)
            {
                return NotFound();
            }
            entity.CategorySubName = model.CategorySubName;
            entity.CategoryID = model.CategoryID;

            if (file != null)
            {
                entity.ImageUrl = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\categorysubs", (file.FileName));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _categorySubService.Update(entity);
            return RedirectToAction("CategorySubList");
        }



        //[HttpPost]
        //public IActionResult DeleteCategorySub(int categorySubID)
        //{
        //    var entity = _categorySubService.GetById(categorySubID);
        //    if (entity != null)
        //    {
        //        _categorySubService.Delete(entity);
        //    }
        //    return RedirectToAction("CategorySubList");
        //}

        [HttpPost]
        public IActionResult DeleteCategorySub(int categorySubID)
        {
            var entity = _categorySubService.GetById(categorySubID);
            if (entity != null)
            {
                _categorySubService.Delete(entity);
            }
            return RedirectToAction("CategorySubList");
        }


    }
}