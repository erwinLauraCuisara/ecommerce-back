using EccomerceApi.Models.DTO;
using EccomerceApi.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EccomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            return Ok(productService.GetProducts());
        }

        [HttpGet("id")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            return Ok(productService.GetProduct(id));
        }


        [HttpPost]
        public ActionResult<ProductDto> CreateProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(productService.CreateProduct(product));
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult<ProductDto> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(productService.UpdateProduct(id, productDto));
        }
    }
}
