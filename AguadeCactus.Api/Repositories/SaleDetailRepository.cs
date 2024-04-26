using Dapper;
using Dapper.Contrib.Extensions;
using AguadeCactus.Api.DataAccess.Interfaces;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories;

public class SaleDetailRepository : ISaleDetailRepository
{
    private readonly IDbContext _dbContext;

    public SaleDetailRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<SaleDetail> SaveAsync(SaleDetail saleDetail)
    {
        saleDetail.id = await _dbContext.Connection.InsertAsync(saleDetail);
        return saleDetail;
    }

    public async Task<SaleDetail> UpdateAsync(SaleDetail saleDetail)
    {
        await _dbContext.Connection.UpdateAsync(saleDetail);
        return saleDetail;
    }

    public async Task<List<SaleDetail>> GetAllAsync()
    {
        const string sql = "SELECT * FROM SaleDetail WHERE IsDeleted = 0";
        var saleDetails = await _dbContext.Connection.QueryAsync<SaleDetail>(sql);
        return saleDetails.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var saleDetail = await GetById(id);
        if (saleDetail == null)
            return false;
        saleDetail.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(saleDetail);
    }

    public async Task<SaleDetail> GetById(int id)
    {
        var saleDetail = await _dbContext.Connection.GetAsync<SaleDetail>(id);
        if (saleDetail == null)
            return null;
        return saleDetail.IsDeleted == true ? null : saleDetail;
    }
}