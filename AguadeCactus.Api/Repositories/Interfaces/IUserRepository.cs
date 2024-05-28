using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface IUserRepository
{
    //Metodo para guardrar las categorias de producto
    Task<User> SaveAsync(User user);
    
    //Metodo para actualizar las categorias de producto
    Task<User> UpdateAsync(User user);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<User>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<User> GetById(int id);
    Task<User> GetLogin(string UserName, string Password);
    Task<User> GetByName(string name, int id = 0);
}