using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategorySub = RouteData.Values["categorysub"]?.ToString(),
                Categories = _categoryService.GetAll()
            }) ;
        }
    }
}
