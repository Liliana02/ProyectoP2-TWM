using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface ISaleRepository
{
    //Metodo para guardrar las categorias de producto
    Task<Sale> SaveAsync(Sale sale);
    
    //Metodo para actualizar las categorias de producto
    Task<Sale> UpdateAsync(Sale sale);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<Sale>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Sale> GetById(int id);
}