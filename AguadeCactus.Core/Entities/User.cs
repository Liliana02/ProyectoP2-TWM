namespace AguadeCactus.Core.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Rol { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
}
