﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Entity;
using ClothBazar.Services;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            var categoryList = categoryService.GetCategory();
            if (!string.IsNullOrEmpty(search))
            {
                categoryList = categoryList.Where(x => x.Name != null && x.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(categoryList);

        }
        // GET: Category
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var categoryByID = categoryService.EditCategory(ID);
            return PartialView(categoryByID);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category =  categoryService.EditCategory(ID);
            categoryService.DeleteCategory(category.ID);
            return RedirectToAction("CategoryTable");
        }
        //[HttpPost]
        //public ActionResult Delete(Category category)
        //{
        //    categoryService.DeleteCategory(category.ID);
        //    return RedirectToAction("Index");
        //}

      
    }
}