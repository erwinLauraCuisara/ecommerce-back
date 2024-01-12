using EccomerceApi.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EccomerceApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Cost { get; set; }

        public string ImageRoute { get; set; }


        public ProductDto toDto()
        {
            return new ProductDto {
                Id = Id,
                Name = Name,
                Description = Description,
                Cost = Cost,
                ImageRoute = ImageRoute,
            };

        }
    }
}
