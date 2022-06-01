using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.WEBUI.Identity;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private IFavoriteService _favoriteService;
        private UserManager<ApplicationUser> _userManager;

        public FavoriteController(IFavoriteService favoriteService, UserManager<ApplicationUser> userManager)
        {
            _favoriteService = favoriteService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var favorite = _favoriteService.GetFavoriteByUserID(_userManager.GetUserId(User));
            return View(new FavoriteModel()
            {
                FavoriteId = favorite.FavoriteID,
                FavoriteItems = favorite.FavoriteItems.Select(i => new FavoriteItemModel()
                {
                    FavoriteItemId = i.FavoriteID,
                    ProductId = i.ProductID,
                    ProductName = i.Product.ProductName,
                    UnitPrice = (decimal)i.Product.UnitPrice,
                    ImageUrl = i.Product.ImageUrl
                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToFavorite(int productId)
        {
            _favoriteService.AddToFavorite(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromFavorite(int productId)
        {
            _favoriteService.RemoveFromFavorite(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }
    }
}
