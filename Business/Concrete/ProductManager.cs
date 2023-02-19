using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constant;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager  : IProductService
    {
         IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;   

        }
        public IDataResult<List<Product>> GetAll() 
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
           
           return new SuccessDataResult<List<Product>>(this.productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(this.productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(this.productDal.GetAll(p =>
                p.UnitPrice >= min && p.UnitPrice < max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(this.productDal.GetProductDetails())  ;
        }

        public IResult Add(Product product)
        {
            //magic strings
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductANameInvalid);
            }
            this.productDal.Add(product);
            return new SuccessResult(Messages.ProductAddedMessage);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(this.productDal.Get(p => p.ProductId == id));
        }
    }
}
