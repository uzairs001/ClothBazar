﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothBazar.Database;
using ClothBazar.Entity;
using System.Data.Entity;

namespace ClothBazar.Services
{
   public class ProductService
    {
       public void SaveProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

       public List<Product> GetProduct()
        {

            //var context = new CBContext();
            //return context.Products.ToList(); 
            using (var context = new CBContext())
            {
                return context.Products.Include(x => x.Category).ToList();

            }
        }

       public Product EditProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);

            }
        }

       public void UpdateProduct(Product product)
       {
           using (var context = new CBContext())
           {
               context.Entry(product).State = System.Data.Entity.EntityState.Modified;
               context.SaveChanges();

           }
       }

       public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
