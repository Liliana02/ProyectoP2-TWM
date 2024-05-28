using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Product;

public class Add : PageModel
{
    [BindProperty] public ProductDto ProductDto { get; set; }
    public string Label { get; set; }
    
    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IProductService _serviceP;
    private readonly ICategoryService _serviceC;
    public List<CategoryDto> Categories { get; set; }
    public List<ProductDto> Products { get; set; }
    [BindProperty]
    public int SelectedOption { get; set; }
    
    public Add(IProductService serviceP, ICategoryService serviceC)
    {
        Categories = new List<CategoryDto>();
        _serviceP = serviceP;
        _serviceC = serviceC;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        ProductDto = new ProductDto();
        
        var responseC = await _serviceC.GetAllAsync();
        Categories = responseC.Data;
        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _serviceP.GetById(id.Value);
            ProductDto = response.Data;
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
            // Actualización
            var categorySelected = new { option = SelectedOption };
            int a = SelectedOption;
            ProductDto.IdCategory = a;
            response = await _serviceP.UpdateAsync(ProductDto);
            
        }
        else
        {
            // Inserción
            var categorySelected = new { option = SelectedOption };
            int a = SelectedOption;
            ProductDto.IdCategory = a;
            response = await _serviceP.SaveAsync(ProductDto);
        }
        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        ProductDto = response.Data;
        return RedirectToPage("./Add");
    }

}