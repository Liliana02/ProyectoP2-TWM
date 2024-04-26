using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;


namespace AguadeCactus.Api.Dto;

public class CategoryDto : DtoBase
{
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
   // [RegularExpression("^(Frappés|Cafés|Smoothies|Crepas|Waffles)$", 
     //   ErrorMessage = "Ingresa una categoria valida (Frappé, Cafés, Smoothies, Crepas o Waffles).")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(100, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Description { get; set; }

    public CategoryDto()
    {
        
    }

    public CategoryDto(Category category)
    {
        id = category.id;
        Name = category.Name;
        Description = category.Description;
    }
}