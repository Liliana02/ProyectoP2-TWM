using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages;

public class AddProduct : PageModel
{
    [BindProperty] public ProductDto ProductDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IProductService _serviceP;


    public AddProduct(IProductService serviceP)
    {
        _serviceP = serviceP;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        ProductDto = new ProductDto();
        
        if (id.HasValue)
        {
            var responseP = await _serviceP.GetById(id.Value);
            ProductDto = responseP.Data;

        }

        if (ProductDto == null)
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
        
        Response<ProductDto> responseP;
        if (ProductDto.id > 0)
        {
            responseP = await _serviceP.UpdateAsync(ProductDto);
        }
        else
        {
            responseP = await _serviceP.SaveAsync(ProductDto);
        }


        Errors = responseP.Errors;
        if (Errors.Count > 0)
        {

            return Page();
        }

        ProductDto = responseP.Data;

        return RedirectToPage("./AddCategoryPayment");
    }
}


