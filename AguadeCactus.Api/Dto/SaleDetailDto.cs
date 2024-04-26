using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AguadeCactus.Api.Dto;

public class SaleDetailDto : DtoBase
{
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 100, ErrorMessage = "Ingresa una cantidad.")]
    public int Quantity { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 999.99, ErrorMessage = "Ingrese el subtotal.")]
    public double Subtotal { get; set; }

    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 1000, ErrorMessage = "Ingresa un número entero.")]
    public int IdProduct { get; set; }

    public SaleDetailDto()
    {
        
    }

    public SaleDetailDto(SaleDetail saleDetail)
    {
        id = saleDetail.id;
        Quantity = saleDetail.Quantity;
        Subtotal = saleDetail.Subtotal;
        IdProduct = saleDetail.IdProduct;
    }
}