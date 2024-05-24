using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface IPromotionService
{
    Task<bool> PromotionExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<PromotionDto> SaveAsync(PromotionDto promotion);
    
    //Metodo para actualizar las categorias de producto
    Task<PromotionDto> UpdateAsync(PromotionDto promotion);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<PromotionDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<PromotionDto> GetById(int id);
    Task<bool> ExistByName(string name, int id = 0);
}