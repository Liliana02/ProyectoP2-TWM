using AguadeCactus.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AguadeCactus.Api.Dto;

public class UserDto : DtoBase
{
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Name { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string LastName { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string UserName { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(45, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    public string Password { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(20, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    [RegularExpression("^(Administrador|Empleado)$", ErrorMessage = "Ingresa un Rol válido (Administrador o Empleado).")]
    public string Rol { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(20, ErrorMessage = "Haz exedido la cantidad de carácteres permitidos.")]
    [RegularExpression("^(Masculino|Femenino|No binario)$", ErrorMessage = "Ingresa un género válido (Masculino, Femenino o No binario).")]
    public string Gender { get; set; }
    [Required (ErrorMessage = "Este campo es obligatorio.")]
    [Range(15, 100, ErrorMessage = "Ingresa una edad válida (15-100).")]
    public int Age { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(User user)
    {
        id = user.id;
        Name = user.Name;
        LastName = user.LastName;
        UserName = user.UserName;
        Password = user.Password;
        Rol = user.Rol;
        Gender = user.Gender;
        Age = user.Age;
    }
}