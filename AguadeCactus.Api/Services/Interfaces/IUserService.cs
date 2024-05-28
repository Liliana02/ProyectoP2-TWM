using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface IUserService
{
    Task<bool> UserExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<UserDto> SaveAsync(UserDto user);
    
    //Metodo para actualizar las categorias de producto
    Task<UserDto> UpdateAsync(UserDto user);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<UserDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<UserDto> GetById(int id);
    Task<bool> ExistByName(string name, int id = 0);
    Task<UserDto> LoginAsync(string UserName, string Password);
}