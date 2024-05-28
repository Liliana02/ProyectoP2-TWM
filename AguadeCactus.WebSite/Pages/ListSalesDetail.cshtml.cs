using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Sale;

public class ListSalesDetail : PageModel
{
    private readonly ISaleDetailService _serviceD;
    private readonly ISaleService _serviceS;
    
    public List<SaleDetailDto> SaleDetails { get; set; }
    public List<SaleDto> Sales { get; set; }

    public ListSalesDetail(ISaleDetailService serviceD, ISaleService serviceS)
    {
        SaleDetails = new List<SaleDetailDto>();
        Sales = new List<SaleDto>();
        _serviceD = serviceD;
        _serviceS = serviceS;
    }
    public async Task<IActionResult> OnGet()
    {
        var responseD = await _serviceD.GetAllAsync();
        var responseS = await _serviceS.GetAllAsync();
        SaleDetails = responseD.Data;
        Sales = responseS.Data;

        return Page();
    }
}