using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface IProductRepository
{
    //Metodo para guardrar las categorias de producto
    Task<Product> SaveAsync(Product product);
    
    //Metodo para actualizar las categorias de producto
    Task<Product> UpdateAsync(Product product);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<Product>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Product> GetById(int id);
    
    //Metodo para implementar categorias
    Task<int> GetCategoryIdByProductId(int productId);
    Task<Product> GetByName(string name, int id = 0);
}