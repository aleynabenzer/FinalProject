using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    //IProductDal I interface Product hangi tabloya karşılık geldiği Dal hangi katmana geldiği
     public interface IProductDal:IEntityRepository<Product>
    {
        


    }
}
// code refactoring kod iyileştirmesi demek