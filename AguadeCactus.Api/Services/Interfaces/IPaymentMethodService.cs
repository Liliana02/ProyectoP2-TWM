using AguadeCactus.Api.Dto;

namespace AguadeCactus.Api.Services.Interfaces;

public interface IPaymentMethodService
{
    Task<bool> PaymentMethodExist(int id);
    
    //Metodo para guardrar las categorias de producto
    Task<PaymentMethodDto> SaveAsync(PaymentMethodDto paymentMethod);
    
    //Metodo para actualizar las categorias de producto
    Task<PaymentMethodDto> UpdateAsync(PaymentMethodDto paymentMethod);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<PaymentMethodDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<PaymentMethodDto> GetById(int id);
}