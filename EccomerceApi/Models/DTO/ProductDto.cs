using System.ComponentModel.DataAnnotations;

namespace EccomerceApi.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Cost { get; set; }
        public string ImageRoute { get; set; }

        public Product toModel()
        {
            return new Product {
                Id = Id,
                Name = Name,
                Description = Description,
                Cost = Cost,
                ImageRoute = ImageRoute
            };
        }

    }
}
