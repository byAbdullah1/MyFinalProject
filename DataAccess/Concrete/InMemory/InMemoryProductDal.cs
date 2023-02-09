using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> products;
        public InMemoryProductDal()
        {
            products = new List<Product> {
                new Product {ProductId=1,ProductName="Glass",UnitPrice=15,UnitsInStock=15, CategoryId=1},
                new Product {ProductId=2,ProductName="Camera",UnitPrice=500,UnitsInStock=3, CategoryId=1},
                new Product {ProductId=3,ProductName="Phone",UnitPrice=1500,UnitsInStock=2, CategoryId=2},
                new Product {ProductId=4,ProductName="keyboard",UnitPrice=150,UnitsInStock=65, CategoryId=2},
                new Product {ProductId=5,ProductName="Mouse",UnitPrice=85,UnitsInStock=1 , CategoryId=2},
            };
        }
        public void Add(Product product)
        {
            this.products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (var p in this.products)
            //{
            //    if (p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;    
            //    }

            //}
            Product productToDelete = this.products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            this.products.Remove(productToDelete);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return this.products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return this.products.Where(p => p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
           Product productToUpdate = this.products.SingleOrDefault(p => p.ProductId == product.ProductId);
           productToUpdate.ProductName=product.ProductName;
           productToUpdate.UnitPrice=product.UnitPrice;
           productToUpdate.UnitsInStock=product.UnitsInStock;
           productToUpdate.CategoryId=product.CategoryId;

           
            
        }
    }
}
