using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    //Context : db tabloları ile proje classları bağlamak 
    public class EfEntityRepositoryBase<TEntity, TContext>
        where TEntity: class, IEntity, new()
        where TContext : DbContext, new()

    {
       
        

    }
}
