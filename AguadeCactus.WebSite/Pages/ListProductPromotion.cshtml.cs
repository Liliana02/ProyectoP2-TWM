using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Product;

public class ListProductPromotion : PageModel
{
    private readonly IProductService _serviceP;
    private readonly IPromotionService _servicePr;
    
    public List<ProductDto> Products { get; set; }
    public List<PromotionDto> Promotions { get; set; }

    public ListProductPromotion(IProductService serviceP, IPromotionService servicePr)
    {
        Products = new List<ProductDto>();
        Promotions = new List<PromotionDto>();
        _serviceP = serviceP;
        _servicePr = servicePr;
    }
    public async Task<IActionResult> OnGet()
    {
        var responseP = await _serviceP.GetAllAsync();
        var responsePr = await _servicePr.GetAllAsync();
        Products = responseP.Data;
        Promotions = responsePr.Data;

        return Page();
    }
}