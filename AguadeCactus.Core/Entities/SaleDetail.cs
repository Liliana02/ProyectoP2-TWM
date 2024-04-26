namespace AguadeCactus.Core.Entities;

public class SaleDetail : EntityBase
{
    public int Quantity { get; set; }
    public double Subtotal { get; set; }
    public int IdProduct { get; set; }
}

