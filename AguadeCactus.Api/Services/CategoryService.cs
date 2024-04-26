using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> CategoryExist(int id)
    {
        var category = await _categoryRepository.GetById(id);
        return (category != null);
    }

    public async Task<CategoryDto> SaveAsync(CategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        category = await _categoryRepository.SaveAsync(category);
        categoryDto.id = category.id;

        return categoryDto;
    }

    public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
    {
        var category = await _categoryRepository.GetById(categoryDto.id);
        
        if (category == null)
            throw new Exception("Category Not Found");
        
        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdatedDate = DateTime.Now;
        await _categoryRepository.UpdateAsync(category);
        
        return categoryDto;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new CategoryDto(c)).ToList();
        return categoriesDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _categoryRepository.DeleteAsync(id);
    }

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        if (category == null)
            throw new Exception("Category not Found");
        
        var categoryDto = new CategoryDto(category);
        return categoryDto;
    }
}