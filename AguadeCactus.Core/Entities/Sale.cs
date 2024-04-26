namespace AguadeCactus.Core.Entities;

public class Sale : EntityBase
{
    public DateTime Date { get; set; }
    public double Total { get; set; }
    public int IdUser { get; set; }
    public int IdSaleDetail { get; set; }
    public int IdPaymentMethod { get; set; }
}
