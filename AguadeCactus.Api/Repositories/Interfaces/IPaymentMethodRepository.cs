using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Repositories.Interfaces;

public interface IPaymentMethodRepository
{
    //Metodo para guardrar las categorias de producto
    Task<PaymentMethod> SaveAsync(PaymentMethod paymentMethod);
    
    //Metodo para actualizar las categorias de producto
    Task<PaymentMethod> UpdateAsync(PaymentMethod paymentMethod);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<PaymentMethod>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<PaymentMethod> GetById(int id);
    //Metodo para obtener una categoria por nombre
    Task<PaymentMethod> GetByName(string name, int id = 0);
}