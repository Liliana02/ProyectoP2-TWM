using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AguadeCactus.Api.Dto;

public class ProductDto : DtoBase
{
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(100, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Description { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 500, ErrorMessage = "Ingresa un precio (0.00-500.00).")]
    public double Price { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression("^(Chico|Mediano|Grande)$", 
        ErrorMessage = "Ingresa un tamaño valido (Chico, Mediano o Grande).")]
    [StringLength(20, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Size { get; set; }
    [Range(0, 1000, ErrorMessage = "Ingresa un número entero.")]
    public int IdCategory { get; set; }

    public ProductDto()
    {
        
    }

    public ProductDto(Product product)
    {
        id = product.id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Size = product.Size;
        IdCategory = product.IdCategory;
    }
}