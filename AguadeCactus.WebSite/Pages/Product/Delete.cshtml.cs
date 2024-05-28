using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Product;

public class Delete : PageModel
{
    [BindProperty] public ProductDto ProductDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IProductService _serviceP;
    private readonly ICategoryService _serviceC;
    
    public List<CategoryDto> Categories { get; set; }
    [BindProperty] public int SelectedOption { get; set; }

    public Delete(IProductService serviceP, ICategoryService serviceC)
    {
        Categories = new List<CategoryDto>();
        _serviceP = serviceP;
        _serviceC = serviceC;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        ProductDto = new ProductDto();
        var responseP = await _serviceP.GetById(id);
        ProductDto = responseP.Data;

        if (ProductDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var responseP = await _serviceP.DeleteAsync(ProductDto.id);
        return RedirectToPage("./List");
    }
}