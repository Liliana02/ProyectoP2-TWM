using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AguadeCactus.Api.Dto;

public class PaymentMethodDto : DtoBase
{
    public int id { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    //[RegularExpression("^(Efectivo|Transferencia|Tarjeta)$", 
      //  ErrorMessage = "Ingresa un método de pago valido (Efectivo, Transferencia o Tarjeta).")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(100, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Description { get; set; }

    public PaymentMethodDto()
    {
        
    }

    public PaymentMethodDto(PaymentMethod paymentMethod)
    {
        id = paymentMethod.id;
        Name = paymentMethod.Name;
        Description = paymentMethod.Description;
    }
}