using Newtonsoft.Json;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public class SaleService : ISaleService
{
    private readonly string _baseURL = "http://localhost:5080/";
    private readonly string _endpoint = "";

    public SaleService()
    {
        
    }

    public async Task<Response<List<SaleDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<SaleDto>>>(json);

        return response;
    }

    public async Task<Response<SaleDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<SaleDto>>(json);

        return response;
    }

    public async Task<Response<SaleDto>> SaveAsync(SaleDto saleDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(saleDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<SaleDto>>(json);

        return response;
    }

    public async Task<Response<SaleDto>> UpdateAsync(SaleDto saleDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(saleDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<SaleDto>>(json);

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