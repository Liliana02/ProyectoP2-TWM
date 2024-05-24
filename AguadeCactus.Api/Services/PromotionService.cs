using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class PromotionService : IPromotionService
{
    private readonly IPromotionRepository _promotionRepository;

    public PromotionService(IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task<bool> PromotionExist(int id)
    {
        var promotion = await _promotionRepository.GetById(id);
        return (promotion != null);
    }

    public async Task<PromotionDto> SaveAsync(PromotionDto promotionDto)
    {
        var promotion = new Promotion
        {
            Name = promotionDto.Name,
            Description = promotionDto.Description,
            Duration = promotionDto.Duration,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        promotion = await _promotionRepository.SaveAsync(promotion);
        promotionDto.id = promotion.id;

        return promotionDto;
    }

    public async Task<PromotionDto> UpdateAsync(PromotionDto promotionDto)
    {
        var promotion = await _promotionRepository.GetById(promotionDto.id);
        
        if (promotion == null)
            throw new Exception("Promotion Not Found");
        
        promotion.Name = promotionDto.Name;
        promotion.Description = promotionDto.Description;
        promotion.Duration = promotionDto.Duration;
        promotion.UpdatedBy = "";
        promotion.UpdatedDate = DateTime.Now;
        await _promotionRepository.UpdateAsync(promotion);
        
        return promotionDto;
    }

    public async Task<List<PromotionDto>> GetAllAsync()
    {
        var promotions = await _promotionRepository.GetAllAsync();
        var promotionsDto =
            promotions.Select(c => new PromotionDto(c)).ToList();
        return promotionsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _promotionRepository.DeleteAsync(id);
    }

    public async Task<PromotionDto> GetById(int id)
    {
        var promotion = await _promotionRepository.GetById(id);
        if (promotion == null)
            throw new Exception("Promotion not Found");
        
        var promotionDto = new PromotionDto(promotion);
        return promotionDto;
    }

    public async Task<bool> ExistByName(string name, int id = 0)
    {
        var promotion = await _promotionRepository.GetByName(name, id);
        return promotion != null;
    }
}