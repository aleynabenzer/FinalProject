using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    //Context : db tabloları ile proje classları bağlamak 
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            //buradaki using : IDisposable pattern implementation of c# , denilen bir c# dökümantasyonu 
            using (TContext context = new TContext())
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

        public void Delete(TEntity entity)
        {

            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }



        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //bu tek data getirir
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

                // singleofdefault belirtilen koşulda sadece bir eleman getirir
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //bu tüm dataları getirir
            using (TContext context = new TContext())
            {
                return filter==null 
                    ? context.Set<TEntity>().ToList() //null ise bu komutu döndür
                    : context.Set<TEntity>().Where(filter).ToList();  // değilse bu komutu döndür  //where filtreyi çeker 
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();


            }
        }
        

    }
}
