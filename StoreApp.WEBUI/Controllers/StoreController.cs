using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.Entities;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Controllers
{
    public class StoreController : Controller
    {
        private IProductService _productService;
        public StoreController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product==null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                CategorySubs = product.ProductCategorySubs.Select(i => i.CategorySub).ToList()
            }) ;
        }

        public IActionResult Products(string searchString,string categorysub, int page=1)
        {
            const int pageSize = 9;
            return View(new ProductListModel()
            {
                PageInfo= new PageInfo()
                {
                    TotalItems= _productService.GetCountByCategorySub(categorysub,searchString),
                    CurrentPage=page,
                    ItemsPerPage=pageSize,
                    CurrentCategorySub=categorysub,
                    SearchText=searchString
                },
                Products = _productService.GetProductsByCategorySub(categorysub,page,pageSize,searchString)
            }) ;
        }
    }
}
