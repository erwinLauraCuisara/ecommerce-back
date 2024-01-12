using EccomerceApi.Config;
using EccomerceApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EccomerceApi.Services.ProductService
{
    public class ProductServiceImpl : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductServiceImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ProductDto CreateProduct(ProductDto product)
        {
            var created = _dbContext.Products.Add(product.toModel()).Entity;
            _dbContext.SaveChanges();
            return created.toDto();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(product => product.Id == id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public ProductDto GetProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(product => product.Id == id);
            return product.toDto();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _dbContext.Products.ToList().Select(product => product.toDto());
        }

        public ProductDto UpdateProduct(int id, ProductDto productDto)
        {
            var product = _dbContext.Products.FirstOrDefault(product => product.Id == id);

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Cost = productDto.Cost;
            product.ImageRoute = productDto.ImageRoute;

            product =_dbContext.Update(product).Entity;
            _dbContext.SaveChanges();

            return product.toDto();
        }
    }
}
