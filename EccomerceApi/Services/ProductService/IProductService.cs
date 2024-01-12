using EccomerceApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EccomerceApi.Services.ProductService
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetProducts();
        public ProductDto GetProduct(int id);
        public ProductDto CreateProduct(ProductDto product);
        public void DeleteProduct(int id);
        public ProductDto UpdateProduct(int id, ProductDto productDto);
    }
}
