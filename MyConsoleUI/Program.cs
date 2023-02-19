using System.Diagnostics.CodeAnalysis;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace MyConsoleUI
{
    internal class Program
    {
        static void Main (string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result2 = productManager.Add(new Product()
                { CategoryId = 1, UnitPrice = 500, ProductName = "Kemer kese kağıdı", UnitsInStock = 3 });
            Console.WriteLine(result2.Message);
           
           
                var result = productManager.GetAll();
                if (result.IsSuccess == true)
                {

                    foreach (var p in result.Data)
                    {
                        Console.WriteLine(p.ProductName);


                    }

                    Console.WriteLine(result.Message);
                }





                else
                {
                    Console.WriteLine(result.Message);
                }
            }












        }
    }
