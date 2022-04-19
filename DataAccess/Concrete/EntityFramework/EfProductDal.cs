using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //nuget
    //veritabanı işlemi yapma süreci: entity framework

    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //buradaki using : IDisposable pattern implementation of c# , denilen bir c# dökümantasyonu 
            using (NorthwindContext context = new NorthwindContext())
            {
                //işlem bitince array i hızlıca temizler

                // gönderilen veri kaynağından bir bir veri ile eşleştirmek için kullanılır 

                //state durum demek

                var addedEntity = context.Entry(entity);  //referansı yakala
                addedEntity.State = EntityState.Added;   //eklenecek nesne 
                context.SaveChanges();                   //ekle
               
                //savechanges işlem gerçekleştirir     

            }
        }

        public void Delete(Product entity)
        {

            using (NorthwindContext context = new NorthwindContext())
            {

                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //bu tek data getirir
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

                // singleofdefault belirtilen koşulda sadece bir eleman getirir
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //bu tüm dataları getirir
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter==null 
                    ? context.Set<Product>().ToList() //null ise bu komutu döndür
                    : context.Set<Product>().Where(filter).ToList();  // değilse bu komutu döndür  //where filtreyi çeker 
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();


            }
        }
    }
}
