using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface IProductService
{
    Task<bool> ProductExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<ProductDto> SaveAsync(ProductDto product);
    
    //Metodo para actualizar las categorias de producto
    Task<ProductDto> UpdateAsync(ProductDto product);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<ProductDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductDto> GetById(int id);
}