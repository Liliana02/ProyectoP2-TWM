using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services.Interfaces;

public interface ISaleDetailService
{
    Task<Response<List<SaleDetailDto>>> GetAllAsync();
    Task<Response<SaleDetailDto>> GetById(int id);
    Task<Response<SaleDetailDto>> SaveAsync(SaleDetailDto saleDetailDto);
    Task<Response<SaleDetailDto>> UpdateAsync(SaleDetailDto saleDetailDto);
    Task<Response<bool>> DeleteAsync(int id);
}