using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services.Interfaces;

public interface IPaymentMethodService
{
    Task<Response<List<PaymentMethodDto>>> GetAllAsync();
    Task<Response<PaymentMethodDto>> GetById(int id);
    Task<Response<PaymentMethodDto>> SaveAsync(PaymentMethodDto paymentMethodDto);
    Task<Response<PaymentMethodDto>> UpdateAsync(PaymentMethodDto paymentMethodDto);
    Task<Response<bool>> DeleteAsync(int id);    
}