using Newtonsoft.Json;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly string _baseURL = "http://localhost:5080/";
    private readonly string _endpoint = "api/paymentmethod";

    public PaymentMethodService()
    {
        
    }

    public async Task<Response<List<PaymentMethodDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<PaymentMethodDto>>>(json);

        return response;
    }

    public async Task<Response<PaymentMethodDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<PaymentMethodDto>>(json);

        return response;
    }

    public async Task<Response<PaymentMethodDto>> SaveAsync(PaymentMethodDto paymentMethodDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(paymentMethodDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<PaymentMethodDto>>(json);

        return response;
    }

    public async Task<Response<PaymentMethodDto>> UpdateAsync(PaymentMethodDto paymentMethodDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(paymentMethodDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<PaymentMethodDto>>(json);

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        
        var response  = JsonConvert.DeserializeObject<Response<bool>>(json);
        
        return response;
    }
}