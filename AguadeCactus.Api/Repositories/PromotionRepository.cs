using Dapper;
using Dapper.Contrib.Extensions;
using AguadeCactus.Api.DataAccess.Interfaces;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories;

public class PromotionRepository : IPromotionRepository
{
    private readonly IDbContext _dbContext;

    public PromotionRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Promotion> SaveAsync(Promotion promotion)
    {
        promotion.id = await _dbContext.Connection.InsertAsync(promotion);
        return promotion;
    }

    public async Task<Promotion> UpdateAsync(Promotion promotion)
    {
        await _dbContext.Connection.UpdateAsync(promotion);
        return promotion;
    }

    public async Task<List<Promotion>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Promotion WHERE IsDeleted = 0";
        var promotions = await _dbContext.Connection.QueryAsync<Promotion>(sql);
        return promotions.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var promotion = await GetById(id);
        if (promotion == null)
            return false;
        promotion.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(promotion);
    }

    public async Task<Promotion> GetById(int id)
    {
        var promotion = await _dbContext.Connection.GetAsync<Promotion>(id);
        if (promotion == null)
            return null;
        return promotion.IsDeleted == true ? null : promotion;
    }

    public async Task<Promotion> GetByName(string name, int id = 0)
    {
        string sql = $"SELECT * FROM Promotion WHERE Name = '{name}' AND id <> {id}";
        var promotions = await _dbContext.Connection.QueryAsync<Promotion>(sql);
        return promotions.ToList().FirstOrDefault();
    }
}