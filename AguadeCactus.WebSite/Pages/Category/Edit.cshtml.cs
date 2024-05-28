using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Category;

public class Edit : PageModel
{
    [BindProperty] public CategoryDto CategoryDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly ICategoryService _service;

    public Edit(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        CategoryDto = new CategoryDto();

        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            CategoryDto = response.Data;
        }

        if (CategoryDto == null)
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

        Response<CategoryDto> response;
        if (CategoryDto.id > 0)
        {
            //Actualización
            response = await _service.UpdateAsync(CategoryDto);
        }
        else
        {
            //Insercción
            response = await _service.SaveAsync(CategoryDto);
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        CategoryDto = response.Data;
        return RedirectToPage("/AddCategoryPayment");
    }
}