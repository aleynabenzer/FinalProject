using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    //IProductDal I interface Product hangi tabloya karşılık geldiği Dal hangi katmana geldiği
     public interface IProductDal
    {
        List<Product> GetAll();

        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

    }
}
