using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Category;

public class Delete : PageModel
{
    [BindProperty] public CategoryDto CategoryDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    private readonly ICategoryService _service;

    public Delete(ICategoryService service)
    {
        _service = service;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        CategoryDto = new CategoryDto();
        var response = await _service.GetById(id);
        CategoryDto = response.Data;

        if (CategoryDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(CategoryDto.id);
        return RedirectToPage("/AddCategoryPayment");
    }
}