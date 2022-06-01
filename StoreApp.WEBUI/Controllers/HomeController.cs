using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Business.Abstract;
using StoreApp.WEBUI.Models;

namespace StoreApp.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private IAdvertisedService _advertisedService;

        public HomeController(IAdvertisedService advertisedService)
        {
            _advertisedService = advertisedService;  
        }
        public IActionResult Index()
        {
            return View(new AdvertisedListModel()
            {
                Advertiseds = _advertisedService.GetAll()
                
            });
            
        }
    }
}
