using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.PaymentMethod;

public class Edit : PageModel
{
    [BindProperty] public PaymentMethodDto PaymentMethodDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IPaymentMethodService _service;

    public Edit(IPaymentMethodService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        PaymentMethodDto = new PaymentMethodDto();

        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            PaymentMethodDto = response.Data;
        }

        if (PaymentMethodDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<PaymentMethodDto> response;
        if (PaymentMethodDto.id > 0)
        {
            //Actualización
            response = await _service.UpdateAsync(PaymentMethodDto);
        }
        else
        {
            //Insercción
            response = await _service.SaveAsync(PaymentMethodDto);
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        PaymentMethodDto = response.Data;
        return RedirectToPage("/AddCategoryPayment");
    }
}