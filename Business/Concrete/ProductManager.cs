using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;


        //inception ekledik 
        // IProductDal olarak referans ver demek
        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // iş kodları
            //return kodu geriye döndürerek ileri satırlara gitmesini engeller
            return _productDal.GetAll();
            //getall içine p => p.CategoryId == x yazarak istediğimiz kategorideki nesneleri getirebiliriz

        }

        public List<Product> GetAllCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnityPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
