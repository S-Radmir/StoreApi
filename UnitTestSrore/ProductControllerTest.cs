using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Store.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Store.Models;
using Moq;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UnitTestSrore.Tests
{
    public class ProductControllerTest
    {
        DbContextOptions<StorageContext> options;
        public ProductControllerTest()
        {
            options = new DbContextOptionsBuilder<StorageContext>()
           .UseInMemoryDatabase(databaseName: "Store")
           .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new StorageContext(options))
            {
                if (context.Product.Count() < 1)
                {
                    context.Product.Add(new Product { Id = 1, Name = "Товар 1", Description = "товар номер раз" });
                    context.Product.Add(new Product { Id = 2, Name = "Товар 2", Description = "товар номер два" });
                    context.Product.Add(new Product { Id = 3, Name = "Товар 3", Description = "товар номер три" });

                    context.SaveChanges();
                }
            }
        }

        [Fact]
        public void IndexViewResultProduct()
        {
            // Use a clean instance of the context to run the test
            using (var context = new StorageContext(options))
            {
                ProductsController storeRepository = new ProductsController(context);
                var products = storeRepository.GetProduct(3);

                Assert.Equal("Товар 3", products.Result.Value.Name);
            }

        }

        [Fact]
        public void IndexViewResult()
        {
            // Use a clean instance of the context to run the test
            using (var context = new StorageContext(options))
            {
                ProductsController storeRepository = new ProductsController(context);
                var products = storeRepository.GetProduct();

                Assert.Equal(3, products.Result.Value.Count());
            }
        }

    }
}
