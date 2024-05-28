using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.PaymentMethod;

public class Delete : PageModel
{
    [BindProperty] public PaymentMethodDto PaymentMethodDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    private readonly IPaymentMethodService _service;

    public Delete(IPaymentMethodService service)
    {
        _service = service;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        PaymentMethodDto = new PaymentMethodDto();
        var response = await _service.GetById(id);
        PaymentMethodDto = response.Data;

        if (PaymentMethodDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(PaymentMethodDto.id);
        return RedirectToPage("/AddCategoryPayment");
    }
}