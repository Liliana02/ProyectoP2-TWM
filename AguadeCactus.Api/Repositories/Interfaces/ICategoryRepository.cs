using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface ICategoryRepository
{
    //Metodo para guardrar las categorias de producto
    Task<Category> SaveAsync(Category category);
    
    //Metodo para actualizar las categorias de producto
    Task<Category> UpdateAsync(Category category);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<Category>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Category> GetById(int id);
}