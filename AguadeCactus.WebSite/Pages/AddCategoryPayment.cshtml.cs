using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Category;

public class AddCategoryPayment : PageModel
{
    [BindProperty] public CategoryDto CategoryDto { get; set; }
    [BindProperty] public PaymentMethodDto PaymentMethodDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly ICategoryService _serviceC;
    private readonly IPaymentMethodService _serviceP;

    public AddCategoryPayment(ICategoryService serviceC, IPaymentMethodService serviceP)
    {
        _serviceC = serviceC;
        _serviceP = serviceP;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        CategoryDto = new CategoryDto();
        PaymentMethodDto = new PaymentMethodDto();

        if (id.HasValue)
        {
            var responseC = await _serviceC.GetById(id.Value);
            var responseP = await _serviceP.GetById(id.Value);
            CategoryDto = responseC.Data;
            PaymentMethodDto = responseP.Data;
        }

        if (CategoryDto == null)
        {
            return Redirect("/Error");
        }
        if (PaymentMethodDto == null)
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

        Response<CategoryDto> responseC;
        if (CategoryDto.id > 0)
        {
            //Actualización
            responseC = await _serviceC.UpdateAsync(CategoryDto);
        }
        else
        {
            //Insercción
            responseC = await _serviceC.SaveAsync(CategoryDto);
        }
        Response<PaymentMethodDto> responseP;
        if (PaymentMethodDto.id > 0)
        {
            //Actualización
            responseP = await _serviceP.UpdateAsync(PaymentMethodDto);
        }
        else
        {
            //Insercción
            responseP = await _serviceP.SaveAsync(PaymentMethodDto);
        }

        Errors = responseC.Errors;
        Errors = responseP.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        CategoryDto = responseC.Data;
        PaymentMethodDto = responseP.Data;
        return RedirectToPage("./AddCategoryPayment");
    }
}