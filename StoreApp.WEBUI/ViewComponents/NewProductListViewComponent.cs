using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.ViewComponents
{
    public class NewProductListViewComponent : ViewComponent
    {
        
            private IProductService _productService;

            public NewProductListViewComponent(IProductService productService)
            {
                _productService = productService;
            }
            public IViewComponentResult Invoke()
            {
                return View(new NewProductListViewModel()
                {
                    Products = _productService.GetNewProducts()
                });
            }
       
    }
}
