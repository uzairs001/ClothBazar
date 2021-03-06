﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Web.ViewModels;
using ClothBazar.Services;

namespace ClothBazar.Web.Controllers
{
    public class HomeController : Controller
    {
        HomeViewModel model = new HomeViewModel();
       

        public ActionResult Index()
        {
            model.category = CategoryService.Instance.GetFeaturedCategory();
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}