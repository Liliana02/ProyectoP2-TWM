using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface IPromotionRepository
{
    //Metodo para guardrar las categorias de producto
    Task<Promotion> SaveAsync(Promotion promotion);
    
    //Metodo para actualizar las categorias de producto
    Task<Promotion> UpdateAsync(Promotion promotion);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<Promotion>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Promotion> GetById(int id);
    Task<Promotion> GetByName(string name, int id = 0);
}