using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AguadeCactus.Api.Dto;

public class SaleDto : DtoBase
{
    public int id { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
    [Range(typeof(DateTime), "2022-01-01", "2050-12-31", ErrorMessage = "Ingrese una fecha válida.")]
    public DateTime Date { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 999.99, ErrorMessage = "Ingrese el total.")]
    public double Total { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 1000, ErrorMessage = "Ingresa un número entero.")]
    public int IdUser { get; set; }
    public int IdSaleDetail { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(0, 1000, ErrorMessage = "Ingresa un número entero.")]
    public int IdPaymentMethod { get; set; }

    public SaleDto()
    {
        
    }

    public SaleDto(Sale sale)
    {
        id = sale.id;
        Date = sale.Date;
        Total = sale.Total;
        IdUser = sale.IdUser;
        IdSaleDetail = sale.IdSaleDetail;
        IdPaymentMethod = sale.IdPaymentMethod;
    }
}