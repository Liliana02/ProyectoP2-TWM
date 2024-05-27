using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Promotion;

public class Delete : PageModel
{
    [BindProperty] public PromotionDto PromotionDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    private readonly IPromotionService _service;

    public Delete(IPromotionService service)
    {
        _service = service;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        PromotionDto = new PromotionDto();
        var response = await _service.GetById(id);
        PromotionDto = response.Data;

        if (PromotionDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(PromotionDto.id);
        return RedirectToPage("./AddPromotion");
    }
}