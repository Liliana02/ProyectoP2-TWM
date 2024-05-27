using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AguadeCactus.Api.Dto;

public class PromotionDto : DtoBase
{
    public int id { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(100, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Description { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Duration { get; set; }

    public PromotionDto()
    {
        
    }

    public PromotionDto(Promotion promotion)
    {
        id = promotion.id;
        Name = promotion.Name;
        Description = promotion.Description;
        Duration = promotion.Duration;
    }
}