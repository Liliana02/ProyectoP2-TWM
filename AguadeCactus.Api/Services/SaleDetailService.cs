using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class SaleDetailService : ISaleDetailService
{
    private readonly ISaleDetailRepository _saleDetailRepository;

    public SaleDetailService(ISaleDetailRepository saleDetailRepository)
    {
        _saleDetailRepository = saleDetailRepository;
    }

    public async Task<bool> SaleDetailExist(int id)
    {
        var saleDetail = await _saleDetailRepository.GetById(id);
        return (saleDetail != null);
    }

    public async Task<SaleDetailDto> SaveAsync(SaleDetailDto saleDetailDto)
    {
        var saleDetail = new SaleDetail
        {
            Quantity = saleDetailDto.Quantity,
            Subtotal = saleDetailDto.Subtotal,
            IdProduct = saleDetailDto.IdProduct,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        saleDetail = await _saleDetailRepository.SaveAsync(saleDetail);
        saleDetailDto.id = saleDetail.id;

        return saleDetailDto;
    }

    public async Task<SaleDetailDto> UpdateAsync(SaleDetailDto saleDetailDto)
    {
        var saleDetail = await _saleDetailRepository.GetById(saleDetailDto.id);
        
        if (saleDetail == null)
            throw new Exception("SaleDetail Not Found");
        
        saleDetail.Quantity = saleDetailDto.Quantity;
        saleDetail.Subtotal = saleDetailDto.Subtotal;
        saleDetail.IdProduct = saleDetailDto.IdProduct;
        saleDetail.UpdatedBy = "";
        saleDetail.UpdatedDate = DateTime.Now;
        await _saleDetailRepository.UpdateAsync(saleDetail);
        
        return saleDetailDto;
    }

    public async Task<List<SaleDetailDto>> GetAllAsync()
    {
        var saleDetails = await _saleDetailRepository.GetAllAsync();
        var saleDetailsDto =
            saleDetails.Select(c => new SaleDetailDto(c)).ToList();
        return saleDetailsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _saleDetailRepository.DeleteAsync(id);
    }

    public async Task<SaleDetailDto> GetById(int id)
    {
        var saleDetail = await _saleDetailRepository.GetById(id);
        if (saleDetail == null)
            throw new Exception("SaleDetail not Found");
        
        var saleDetailDto = new SaleDetailDto(saleDetail);
        return saleDetailDto;
    }
}