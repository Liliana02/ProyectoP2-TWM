using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<bool> CategoryExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<CategoryDto> SaveAsync(CategoryDto category);
    
    //Metodo para actualizar las categorias de producto
    Task<CategoryDto> UpdateAsync(CategoryDto category);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<CategoryDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<CategoryDto> GetById(int id);
}