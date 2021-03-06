﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Services;
using ClothBazar.Entity;
using ClothBazar.Web.ViewModels;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        
        
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search,int? pageNo)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();
            pageNo = (pageNo.HasValue) ? pageNo.Value > 0 ? pageNo : 1 : 1;
            model.pageNo = pageNo.Value;
            model.searchTerm = search;
            int totalRecords = ProductService.Instance.GetProductCountSolely(search);
            int pageSize = 3;
            
            //model.Products = ProductService.Instance.GetProduct(pageNo.Value);
            model.Products = ProductService.Instance.GetProduct(search, pageNo.Value, pageSize);
          
            model.pager = new Pager(totalRecords, pageNo, pageSize);
            return PartialView(model);


        }

        public ActionResult Create()
        {
           
           List<Category> cat = CategoryService.Instance.GetFeaturedCategory();
           return PartialView(cat);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
           
            Product newproduct = new Product();
            newproduct.Name = categoryViewModel.Name;
            newproduct.Description = categoryViewModel.Description;
            newproduct.Price = categoryViewModel.Price;
            newproduct.ImageURL = categoryViewModel.imageURL;
            newproduct.Category = CategoryService.Instance.EditCategory(categoryViewModel.CategoryID);
            

            ProductService.Instance.SaveProduct(newproduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var productByID = ProductService.Instance.EditProduct(ID);
            return PartialView(productByID);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductService.Instance.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var product = ProductService.Instance.EditProduct(ID);
            ProductService.Instance.DeleteProduct(product.ID);
            return RedirectToAction("ProductTable");
        }

        public ActionResult Detail(int ID)
        {
            ProductDetails model = new ProductDetails();
            model.Pdetails = ProductService.Instance.EditProduct(ID);
            return View(model);
        }


        
    }
}