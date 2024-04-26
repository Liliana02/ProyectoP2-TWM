using Dapper;
using Dapper.Contrib.Extensions;
using AguadeCactus.Api.DataAccess.Interfaces;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly IDbContext _dbContext;

    public SaleRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Sale> SaveAsync(Sale sale)
    {
        sale.id = await _dbContext.Connection.InsertAsync(sale);
        return sale;
    }

    public async Task<Sale> UpdateAsync(Sale sale)
    {
        await _dbContext.Connection.UpdateAsync(sale);
        return sale;
    }

    public async Task<List<Sale>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Sale WHERE IsDeleted = 0";
        var sales = await _dbContext.Connection.QueryAsync<Sale>(sql);
        return sales.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sale = await GetById(id);
        if (sale == null)
            return false;
        sale.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(sale);
    }

    public async Task<Sale> GetById(int id)
    {
        var sale = await _dbContext.Connection.GetAsync<Sale>(id);
        if (sale == null)
            return null;
        return sale.IsDeleted == true ? null : sale;
    }
}