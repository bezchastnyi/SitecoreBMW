using Feature.Product.Controllers;
using NUnit.Framework;

namespace Feature.Product.Tests.Controllers
{
    public class ProductsByCountryControllerTests
    {
        private ProductsByCountryController _controller;
          
        [SetUp]
        public void Setup()
        {
          this._controller = new ProductsByCountryController();
        }

        [Test]
        public void Index_RenderingContext_ViewVerified()
        {
          // Arrange
          //var countryParameter = "Germany";

          // Act
          //var result = this._controller.Index() as ViewResult;

          // Assert
          //Assert.NotNull(result);
          //Assert.NotNull(result.ViewName);
          //Assert.Equals("Index", result.ViewName);
        }
    }
}