using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Tests.Data
{
    public class ProductsDbSeed
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Products.RemoveRange(db.Products);
            db.Products.AddRange(new List<Product>
            {
                new Product{ Id = 1, Name ="testProduct1", Description ="testProduct1", ImgUri = "http://ahoj.ahoj/1", Price = 10},
                new Product{ Id = 2, Name ="testProduct2", Description ="testProduct2", ImgUri = "http://ahoj.ahoj/2", Price = 20},
                new Product{ Id = 3, Name ="testProduct3", Description ="testProduct3", ImgUri = "http://ahoj.ahoj/3", Price = 30} 
            });
            db.SaveChanges();
        }

    }
}
