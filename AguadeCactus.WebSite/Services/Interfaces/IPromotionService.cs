using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public interface IPromotionService
{
    Task<Response<List<PromotionDto>>> GetAllAsync();
    Task<Response<PromotionDto>> GetById(int id);
    Task<Response<PromotionDto>> SaveAsync(PromotionDto promotionDto);
    Task<Response<PromotionDto>> UpdateAsync(PromotionDto promotionDto);
    Task<Response<bool>> DeleteAsync(int id);
}