namespace AguadeCactus.Core.Entities;
public class Product : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Size { get; set; }
    public int IdCategory { get; set; }
}
