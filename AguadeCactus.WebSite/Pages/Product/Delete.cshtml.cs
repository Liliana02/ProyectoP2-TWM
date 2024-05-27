using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Product;

public class Delete : PageModel
{
    [BindProperty] public ProductDto ProductDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    private readonly IProductService _service;

    public Delete(IProductService service)
    {
        _service = service;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        ProductDto = new ProductDto();
        var response = await _service.GetById(id);
        ProductDto = response.Data;

        if (ProductDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(ProductDto.id);
        return RedirectToPage("./Add");
    }
}