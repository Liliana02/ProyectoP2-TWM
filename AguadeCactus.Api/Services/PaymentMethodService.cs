using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }

    public async Task<bool> PaymentMethodExist(int id)
    {
        var paymentMethod = await _paymentMethodRepository.GetById(id);
        return (paymentMethod != null);
    }

    public async Task<PaymentMethodDto> SaveAsync(PaymentMethodDto paymentMethodDto)
    {
        var paymentMethod = new PaymentMethod
        {
            Name = paymentMethodDto.Name,
            Description = paymentMethodDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        paymentMethod = await _paymentMethodRepository.SaveAsync(paymentMethod);
        paymentMethodDto.id = paymentMethod.id;

        return paymentMethodDto;
    }

    public async Task<PaymentMethodDto> UpdateAsync(PaymentMethodDto paymentMethodDto)
    {
        var paymentMethod = await _paymentMethodRepository.GetById(paymentMethodDto.id);
        
        if (paymentMethod == null)
            throw new Exception("PaymentMethod Not Found");
        
        paymentMethod.Name = paymentMethodDto.Name;
        paymentMethod.Description = paymentMethodDto.Description;
        paymentMethod.UpdatedBy = "";
        paymentMethod.UpdatedDate = DateTime.Now;
        await _paymentMethodRepository.UpdateAsync(paymentMethod);
        
        return paymentMethodDto;
    }

    public async Task<List<PaymentMethodDto>> GetAllAsync()
    {
        var paymentMethods = await _paymentMethodRepository.GetAllAsync();
        var paymentMethodsDto =
            paymentMethods.Select(c => new PaymentMethodDto(c)).ToList();
        return paymentMethodsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _paymentMethodRepository.DeleteAsync(id);
    }

    public async Task<PaymentMethodDto> GetById(int id)
    {
        var paymentMethod = await _paymentMethodRepository.GetById(id);
        if (paymentMethod == null)
            throw new Exception("PaymentMethod not Found");
        
        var paymentMethodDto = new PaymentMethodDto(paymentMethod);
        return paymentMethodDto;
    }

    public async Task<bool> ExistByName(string name, int id = 0)
    {
        var paymentMethod = await _paymentMethodRepository.GetByName(name, id);
        return paymentMethod != null;
    }
}