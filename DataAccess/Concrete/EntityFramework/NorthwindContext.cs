using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    //Context : db tabloları ile proje classları bağlamak 

    public class NorthwindContext:DbContext
    {
        //burası hangi database ile ilişkilendiğimizi belirttiğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //gerçek projede optionsBuilder.UseSqlServer(@"Server=175.45.2.12"); tarzında bir ip yazılır db için 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");

            //burasıbüyük küçük harf kurallarından bağımsızdır
            //database ismi hariç
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
} 
