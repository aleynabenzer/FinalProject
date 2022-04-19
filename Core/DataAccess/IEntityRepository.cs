
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // bu yaptığımız şeyler bir standart oluşturmadır
        //Generic constraint filtreleme olayına denir. genaric kısıt demektir
        //class: referans tip
        //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
        List<T> GetAll(Expression<Func<T,bool>> filter=null); 

        //ayrı ayrı metodlar yazmak yerine (id si adı için) hepsini bu kod ile çekiyoruz
        //   List<T> GetAllByCategory(int categoryId);
        //bunun yerine en üssteki kod yazılır, her birini ayrı ayrı yazmamız gerekmez

        //filtre yoksa tüm datayı istiyor
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);



       





    }

    




















    }
