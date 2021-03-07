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

namespace UnitTestSrore.Tests
{
    public class ProductControllerTest
    {
        //[Fact]
        //public void IndexViewDataMessage()
        //{
        //    // Arrange
        //    var mock = new Mock<StorageContext>();
        //    mock.Setup(repo => repo.Product).Returns(GetProducts());
        //    var controller = new ProductsController(mock.Object);

        //    // Act
        //    Task<ActionResult<IEnumerable<Product>>> result = controller.GetProduct() as Task<ActionResult<IEnumerable<Product>>>;

        //    // Assert
        //    var viewResult = Assert.IsType<Task<ActionResult<IEnumerable<Product>>>>(result);
        //    var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult);
        //    Assert.Equal(GetProducts().Count(), model.Count());
        //}

        //[Fact]
        //public void IndexViewResultNotNull()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;
        //    // Assert
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public void IndexViewNameEqualIndex()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;
        //    // Assert
        //    Assert.Equal("Index", result?.ViewName);
        //}

        Microsoft.EntityFrameworkCore.DbSet<Store.Models.Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Id =1, Name = "Товар 1", Description = "товар номер раз" },
                new Product { Id =2, Name = "Товар 2", Description = "товар номер два" },
                new Product { Id =3, Name = "Товар 3", Description = "товар номер три" },
            };
            return (Microsoft.EntityFrameworkCore.DbSet<Product>)products.AsEnumerable();
        }

    }
}
