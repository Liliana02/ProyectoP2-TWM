using Newtonsoft.Json;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public class PromotionService : IPromotionService
{
    private readonly string _baseURL = "http://localhost:5080/";
    private readonly string _endpoint = "";

    public PromotionService()
    {
        
    }

    public async Task<Response<List<PromotionDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<PromotionDto>>>(json);

        return response;
    }

    public async Task<Response<PromotionDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<PromotionDto>>(json);

        return response;
    }

    public async Task<Response<PromotionDto>> SaveAsync(PromotionDto promotionDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(promotionDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<PromotionDto>>(json);

        return response;
    }

    public async Task<Response<PromotionDto>> UpdateAsync(PromotionDto promotionDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(promotionDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<PromotionDto>>(json);

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