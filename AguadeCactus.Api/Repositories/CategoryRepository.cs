using Dapper;
using Dapper.Contrib.Extensions;
using AguadeCactus.Api.DataAccess.Interfaces;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbContext _dbContext;

    public CategoryRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Category> SaveAsync(Category category)
    {
        category.id = await _dbContext.Connection.InsertAsync(category);
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        await _dbContext.Connection.UpdateAsync(category);
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Category WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<Category>(sql);
        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await GetById(id);
        if (category == null)
            return false;
        category.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(category);
    }

    public async Task<Category> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<Category>(id);
        if (category == null)
            return null;
        return category.IsDeleted == true ? null : category;
    }

    public async Task<Category> GetByName(string name, int id = 0)
    {
        string sql = $"SELECT * FROM Category WHERE Name = '{name}' AND id <> {id}";
        var categories = await _dbContext.Connection.QueryAsync<Category>(sql);
        return categories.ToList().FirstOrDefault();
    }
}