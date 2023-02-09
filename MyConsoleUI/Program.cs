﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace MyConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
           {
               Console.WriteLine(product.ProductName + "/" + product.CategoyName);
            }
           //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
           //foreach (var category in categoryManager.GetAll() )
           //{
           //    Console.WriteLine(category.CategoryName);
               
           //}

        }

        
        
    }
} 