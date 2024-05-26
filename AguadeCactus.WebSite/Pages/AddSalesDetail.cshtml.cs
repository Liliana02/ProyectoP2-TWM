using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Sale;

public class AddSalesDetail : PageModel
{
    [BindProperty] public SaleDetailDto SaleDetailDto { get; set; }
    [BindProperty] public SaleDto SaleDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly ISaleDetailService _serviceD;
    private readonly ISaleService _serviceS;

    public AddSalesDetail(ISaleDetailService serviceD, ISaleService serviceS)
    {
        _serviceD = serviceD;
        _serviceS = serviceS;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        SaleDetailDto = new SaleDetailDto();
        SaleDto = new SaleDto();

        if (id.HasValue)
        {
            var responseD = await _serviceD.GetById(id.Value);
            var responseS = await _serviceS.GetById(id.Value);
            SaleDetailDto = responseD.Data;
            SaleDto = responseS.Data;
        }

        if (SaleDetailDto == null)
        {
            return Redirect("/Error");
        }
        if (SaleDto == null)
        {
            return Redirect("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<SaleDetailDto> responseD;
        if (SaleDetailDto.id > 0)
        {
            //Actualización
            responseD = await _serviceD.UpdateAsync(SaleDetailDto);
        }
        else
        {
            //Insercción
            responseD = await _serviceD.SaveAsync(SaleDetailDto);
        }
        Response<SaleDto> responseS;
        if (SaleDto.id > 0)
        {
            //Actualización
            responseS = await _serviceS.UpdateAsync(SaleDto);
        }
        else
        {
            //Insercción
            responseS = await _serviceS.SaveAsync(SaleDto);
        }

        Errors = responseD.Errors;
        Errors = responseS.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        SaleDetailDto = responseD.Data;
        SaleDto = responseS.Data;
        return RedirectToPage("./AddCategoryPayment");
    }
}