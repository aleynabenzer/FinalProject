using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //burada veriler varmış gibi : dummy data
        

        //global değişken: bütün medodlardan ayrı tanımladığımız için _ ile başlar genelde class içinde ama medod dışında 
        List<Product> _product;

        public InMemoryProductDal()
        {
            _product = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Monitör", UnitPrice=15, UnistInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kasa", UnitPrice=635, UnistInStock=5},
                new Product{ProductId=3, CategoryId=2, ProductName="Laptop", UnitPrice=54, UnistInStock=11},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=55, UnistInStock=54},
                new Product{ProductId=5, CategoryId=3, ProductName="Fare", UnitPrice=41, UnistInStock=1}
            };
        }

        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            //kendmiz bir product oluşturup referansı ona atıyoruz
            //LINQ-- > Language Interated Query -dile gömülü sorgulama
            Product productToDelete = null  ;
            foreach (var p in _product)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }


                productToDelete = _product.SingleOrDefault();









            _product.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
