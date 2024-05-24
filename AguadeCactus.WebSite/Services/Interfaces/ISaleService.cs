using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public interface ISaleService
{
    Task<Response<List<SaleDto>>> GetAllAsync();
    Task<Response<SaleDto>> GetById(int id);
    Task<Response<SaleDto>> SaveAsync(SaleDto saleDto);
    Task<Response<SaleDto>> UpdateAsync(SaleDto saleDto);
    Task<Response<bool>> DeleteAsync(int id);    
}