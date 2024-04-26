using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface ISaleDetailService
{
    Task<bool> SaleDetailExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<SaleDetailDto> SaveAsync(SaleDetailDto saleDetail);
    
    //Metodo para actualizar las categorias de producto
    Task<SaleDetailDto> UpdateAsync(SaleDetailDto saleDetail);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<SaleDetailDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<SaleDetailDto> GetById(int id);
}