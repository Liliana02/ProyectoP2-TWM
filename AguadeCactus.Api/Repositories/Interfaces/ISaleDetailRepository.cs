using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface ISaleDetailRepository
{
    //Metodo para guardrar las categorias de producto
    Task<SaleDetail> SaveAsync(SaleDetail saleDetail);
    
    //Metodo para actualizar las categorias de producto
    Task<SaleDetail> UpdateAsync(SaleDetail saleDetail);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<SaleDetail>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<SaleDetail> GetById(int id);
}