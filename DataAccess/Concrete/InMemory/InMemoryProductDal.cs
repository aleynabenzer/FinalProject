using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Product{ProductId=1, CategoryId=1, ProductName="Monitör", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kasa", UnitPrice=635, UnitsInStock=5},
                new Product{ProductId=3, CategoryId=2, ProductName="Laptop", UnitPrice=54, UnitsInStock=11},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=55, UnitsInStock=54},
                new Product{ProductId=5, CategoryId=3, ProductName="Fare", UnitPrice=41, UnitsInStock=1}
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
            //Lambda işareti =>

            //Product productToDelete = null  ;
            //foreach (var p in _product)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            // yukarıdaki gibi kullanım yapılır ama aşağıdaki daha doğru bir kullanımdır
            // buradaki SingleOrDefault(p  foreach işini yapıyor yani tek tek dolaşıyor
            // SingleOrDefault bir metod tur 

            Product productToDelete = _product.SingleOrDefault(p=>p.ProductId == product.ProductId);

            //burada silinecek elemanı bulduruyoruz


            _product.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _product;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {

            //içerisindeki şarta uyanların hepsini bir liste haline getirir ve döndürür 
            // sql deki where mantığı gibidir where yazdığında yeni bir tablo yapıyordu

            return _product.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            // gönderdiğim ürün id'sine sahip olan listedeki ürünü bulur

            Product productToUpdate = _product.SingleOrDefault(p=>p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;

        }
    }
}
