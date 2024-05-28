using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Product;

public class List : PageModel
{
    private readonly IProductService _serviceP;
    
    public List<ProductDto> Products { get; set; }

    public List(IProductService serviceP)
    {
        Products = new List<ProductDto>();
        _serviceP = serviceP;
    }
    public async Task<IActionResult> OnGet()
    {
        var responseP = await _serviceP.GetAllAsync();
        Products = responseP.Data;

        return Page();
    }
}