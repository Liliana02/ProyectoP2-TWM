using Dapper;
using Dapper.Contrib.Extensions;
using AguadeCactus.Api.DataAccess.Interfaces;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories;

public class PaymentMethodRepository : IPaymentMethodRepository
{
    private readonly IDbContext _dbContext;

    public PaymentMethodRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<PaymentMethod> SaveAsync(PaymentMethod paymentMethod)
    {
        paymentMethod.id = await _dbContext.Connection.InsertAsync(paymentMethod);
        return paymentMethod;
    }

    public async Task<PaymentMethod> UpdateAsync(PaymentMethod paymentMethod)
    {
        await _dbContext.Connection.UpdateAsync(paymentMethod);
        return paymentMethod;
    }

    public async Task<List<PaymentMethod>> GetAllAsync()
    {
        const string sql = "SELECT * FROM PaymentMethod WHERE IsDeleted = 0";
        var paymentMethods = await _dbContext.Connection.QueryAsync<PaymentMethod>(sql);
        return paymentMethods.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var paymentMethod = await GetById(id);
        if (paymentMethod == null)
            return false;
        paymentMethod.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(paymentMethod);
    }

    public async Task<PaymentMethod> GetById(int id)
    {
        var paymentMethod = await _dbContext.Connection.GetAsync<PaymentMethod>(id);
        if (paymentMethod == null)
            return null;
        return paymentMethod.IsDeleted == true ? null : paymentMethod;
    }

    public async Task<PaymentMethod> GetByName(string name, int id = 0)
    {
        string sql = $"SELECT * FROM PaymentMethod WHERE Name = '{name}' AND id <> {id}";
        var paymentMethod = await _dbContext.Connection.QueryAsync<PaymentMethod>(sql);
        return paymentMethod.ToList().FirstOrDefault();   
    }
}