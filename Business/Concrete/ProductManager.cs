using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
         IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;   

        }
        public List<Product> GetAll()
        {
           //iş kodları
           return this.productDal.GetAll();
        }

        public List<Product> GetAllCategoryId(int id)
        {
            return this.productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
           return this.productDal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max);    
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return this.productDal.GetProductDetails();
        }

        public void Add(Product product)
        {
            this.productDal.Add(product);
        }
    }
}
