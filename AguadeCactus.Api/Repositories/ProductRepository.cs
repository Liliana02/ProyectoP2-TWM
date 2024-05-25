using Dapper;
using Dapper.Contrib.Extensions;
using AguadeCactus.Api.DataAccess.Interfaces;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbContext _dbContext;

    public ProductRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Product> SaveAsync(Product product)
    {
        product.id = await _dbContext.Connection.InsertAsync(product);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        await _dbContext.Connection.UpdateAsync(product);
        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Product WHERE IsDeleted = 0";
        var products = await _dbContext.Connection.QueryAsync<Product>(sql);
        return products.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await GetById(id);
        if (product == null)
            return false;
        product.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(product);
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _dbContext.Connection.GetAsync<Product>(id);
        if (product == null)
            return null;
        return product.IsDeleted == true ? null : product;
    }

    public async Task<Product> GetByName(string name, int id = 0)
    {
        string sql = $"SELECT * FROM Product WHERE Name = '{name}' AND id <> {id}";
        var products = await _dbContext.Connection.QueryAsync<Product>(sql);
        return products.ToList().FirstOrDefault();
    }
}