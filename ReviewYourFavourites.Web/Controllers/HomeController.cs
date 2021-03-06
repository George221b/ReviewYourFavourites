﻿namespace ReviewYourFavourites.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Web.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
