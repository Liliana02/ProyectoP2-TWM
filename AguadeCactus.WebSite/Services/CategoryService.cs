using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services.Interfaces;

namespace AguadeCactus.WebSite.Services;

public class CategoryService : ICategoryService
{
    public Task<Response<List<CategoryDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<CategoryDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<CategoryDto>> SaveAsync(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<CategoryDto>> UpdateAsync(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}