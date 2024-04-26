using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<bool> SaleExist(int id)
    {
        var sale = await _saleRepository.GetById(id);
        return (sale != null);
    }

    public async Task<SaleDto> SaveAsync(SaleDto saleDto)
    {
        var sale = new Sale
        {
            Date = saleDto.Date,
            Total = saleDto.Total,
            IdUser = saleDto.IdUser,
            IdSaleDetail = saleDto.IdSaleDetail,
            IdPaymentMethod = saleDto.IdPaymentMethod,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        sale = await _saleRepository.SaveAsync(sale);
        saleDto.id = sale.id;

        return saleDto;
    }

    public async Task<SaleDto> UpdateAsync(SaleDto saleDto)
    {
        var sale = await _saleRepository.GetById(saleDto.id);
        
        if (sale == null)
            throw new Exception("Sale Not Found");
        
        sale.Date = saleDto.Date;
        sale.Total = saleDto.Total;
        sale.IdUser = saleDto.IdUser;
        sale.IdSaleDetail = sale.IdSaleDetail;
        sale.IdPaymentMethod = saleDto.IdPaymentMethod;
        sale.UpdatedBy = "";
        sale.UpdatedDate = DateTime.Now;
        await _saleRepository.UpdateAsync(sale);
        
        return saleDto;
    }

    public async Task<List<SaleDto>> GetAllAsync()
    {
        var sales = await _saleRepository.GetAllAsync();
        var salesDto =
            sales.Select(c => new SaleDto(c)).ToList();
        return salesDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _saleRepository.DeleteAsync(id);
    }

    public async Task<SaleDto> GetById(int id)
    {
        var sale = await _saleRepository.GetById(id);
        if (sale == null)
            throw new Exception("Sale not Found");
        
        var saleDto = new SaleDto(sale);
        return saleDto;
    }
}