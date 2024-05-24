using Newtonsoft.Json;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services;

public class CategoryService : ICategoryService
{
    private readonly string _baseURL = "http://localhost:5080/";
    private readonly string _endpoint = "api/category";

    public CategoryService()
    {
        
    }

    public async Task<Response<List<CategoryDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<CategoryDto>>>(json);

        return response;
    }

    public async Task<Response<CategoryDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";

        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<CategoryDto>>(json);

        return response;
    }

    public async Task<Response<CategoryDto>> SaveAsync(CategoryDto categoryDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(categoryDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<CategoryDto>>(json);

        return response;
    }

    public async Task<Response<CategoryDto>> UpdateAsync(CategoryDto categoryDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(categoryDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<CategoryDto>>(json);

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