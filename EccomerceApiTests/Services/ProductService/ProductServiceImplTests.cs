using Xunit;
using EccomerceApi.Config;
using Moq;
using EccomerceApi.Models;
using EccomerceApi.Models.DTO;

namespace EccomerceApi.Services.ProductService.Tests
{
    public class ProductServiceImplTests
    {

        private readonly Mock<ApplicationDbContext> _context;
        private readonly ProductServiceImpl productServiceImpl;

        public ProductServiceImplTests()
        {
            _context = new Mock<ApplicationDbContext>();
            productServiceImpl = new ProductServiceImpl(_context.Object);
        }


        [Fact]
        public void GetProductTest()
        {
            var productMock = new Product { Id = 3 };

            _context.Setup(repo => repo.Products.FirstOrDefault(It.IsAny<object>())).Returns(productMock);

            var product = productServiceImpl.GetProduct(3);

            Assert.Equal(productMock.Id, product.Id);
        }

        [Fact]
        public void CreateProductTest()
        {
            var productMock = new Product { Id = 3 };
            var productDto = new ProductDto { Id = 3 };
            _context.Setup(repo => repo.Products.Add(It.IsAny<Product>()).Entity).Returns(productMock);

            var product = productServiceImpl.CreateProduct(productDto);

            Assert.Equal(productMock.Id, productDto.Id);
        }


        [Fact]
        public void UpdateProductTest()
        {
            var productMock = new Product { Id = 3 };
            var productDto = new ProductDto { Id = 3 };

            _context.Setup(repo => repo.Products.FirstOrDefault(It.IsAny<object>())).Returns(productMock);
            _context.Setup(repo => repo.Products.Update(It.IsAny<Product>()).Entity).Returns(productMock);

            var product = productServiceImpl.UpdateProduct(3, productDto);

            Assert.Equal(productMock.Id, productDto.Id);
        }
   

        [Fact]
        public void DeleteProductTest()
        {
            var productMock = new Product { Id = 3 };

            _context.Setup(repo => repo.Products.FirstOrDefault(It.IsAny<object>())).Returns(productMock);
            _context.Setup(repo => repo.Products.Remove(It.IsAny<Product>()).Entity).Returns(productMock);

            productServiceImpl.DeleteProduct(3);
        }
    }
}