using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services.Interfaces;

public interface ICategoryService
{
    Task<Response<List<CategoryDto>>> GetAllAsync();
    Task<Response<CategoryDto>> GetById(int id);
    Task<Response<CategoryDto>> SaveAsync(CategoryDto categoryDto);
    Task<Response<CategoryDto>> UpdateAsync(CategoryDto categoryDto);
    Task<Response<bool>> DeleteAsync(int id);
}