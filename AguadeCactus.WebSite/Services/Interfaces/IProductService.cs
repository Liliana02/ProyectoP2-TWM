using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public interface IProductService
{
    Task<Response<List<ProductDto>>> GetAllAsync();
    Task<Response<ProductDto>> GetById(int id);
    Task<Response<ProductDto>> SaveAsync(ProductDto productDto);
    Task<Response<ProductDto>> UpdateAsync(ProductDto productDto);
    Task<Response<bool>> DeleteAsync(int id);
}