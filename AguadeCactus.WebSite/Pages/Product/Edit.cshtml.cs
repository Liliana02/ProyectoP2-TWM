using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Product;

public class Edit : PageModel
{
    [BindProperty] public ProductDto ProductDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IProductService _service;

    public Edit(IProductService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        ProductDto = new ProductDto();

        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            ProductDto = response.Data;
        }

        if (ProductDto == null)
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

        Response<ProductDto> response;
        if (ProductDto.id > 0)
        {
            //Actualización
            response = await _service.UpdateAsync(ProductDto);
        }
        else
        {
            //Insercción
            response = await _service.SaveAsync(ProductDto);
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        ProductDto = response.Data;
        return RedirectToPage("./List");
    }
}