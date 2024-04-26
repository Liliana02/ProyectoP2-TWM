using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface ISaleService
{
    Task<bool> SaleExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<SaleDto> SaveAsync(SaleDto sale);
    
    //Metodo para actualizar las categorias de producto
    Task<SaleDto> UpdateAsync(SaleDto sale);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<SaleDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<SaleDto> GetById(int id);
}