using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.Sale;

public class AddSalesDetail : PageModel
{
    
    [BindProperty] public SaleDetailDto SaleDetailDto { get; set; }
    [BindProperty] public SaleDto SaleDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly ISaleDetailService _serviceD;
    private readonly ISaleService _serviceS;
    private readonly IProductService _serviceP;
    private readonly IUserService _serviceU;
    private readonly IPaymentMethodService _serviceM;

    public List<ProductDto> Products { get; set; }
    public List<UserDto> Users { get; set; }
    public List<SaleDetailDto> SalesDetails { get; set; }
    public List<SaleDto> Sales { get; set; }
    public List<PaymentMethodDto> PaymentMethods { get; set; }
    
    public int SelectedOption { get; set; }

    public AddSalesDetail(ISaleDetailService serviceD, ISaleService serviceS, IProductService serviceP, IUserService serviceU, IPaymentMethodService serviceM)
    {
        Products = new List<ProductDto>();
        Users = new List<UserDto>();
        SalesDetails = new List<SaleDetailDto>();
        PaymentMethods = new List<PaymentMethodDto>();
        _serviceD = serviceD;
        _serviceS = serviceS;
        _serviceP = serviceP;
        _serviceU = serviceU;
        _serviceM = serviceM;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        SaleDetailDto = new SaleDetailDto();
        SaleDto = new SaleDto();

        var responseP = await _serviceP.GetAllAsync();
        var responseU = await _serviceU.GetAllAsync();
        var responseSa = await _serviceD.GetAllAsync();
        var responseM = await _serviceM.GetAllAsync();
        Products = responseP.Data;
        Users = responseU.Data;
        SalesDetails = responseSa.Data;
        PaymentMethods = responseM.Data;
        if (id.HasValue)
        {
            var responseD = await _serviceD.GetById(id.Value);
            var responseS = await _serviceS.GetById(id.Value);
            SaleDetailDto = responseD.Data;
            SaleDto = responseS.Data;
        }

        if (SaleDetailDto == null)
        {
            return Redirect("/Error");
        }
        if (SaleDto == null)
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

        Response<SaleDetailDto> responseD;
        if (SaleDetailDto.id > 0)
        {
            int a = SelectedOption;
            SaleDetailDto.IdProduct = a;
            //Actualización
            responseD = await _serviceD.UpdateAsync(SaleDetailDto);
        }
        else
        {
            int a = SelectedOption;
            SaleDetailDto.IdProduct = a;
            //Insercción
            responseD = await _serviceD.SaveAsync(SaleDetailDto);
        }
        Response<SaleDto> responseS;
        if (SaleDto.id > 0)
        {
            int b = SelectedOption;
            SaleDto.IdSaleDetail = b;
            SaleDto.IdUser = b;
            SaleDto.IdPaymentMethod = b;
            SaleDto.IdPaymentMethod = b;
            //Actualización
            responseS = await _serviceS.UpdateAsync(SaleDto);
        }
        else
        {
            int b = SelectedOption;
            SaleDto.IdSaleDetail = b;
            SaleDto.IdUser = b;
            SaleDto.IdPaymentMethod = b;
            SaleDto.IdPaymentMethod = b;
            //Insercción
            responseS = await _serviceS.SaveAsync(SaleDto);
        }

        Errors = responseD.Errors;
        Errors = responseS.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        SaleDetailDto = responseD.Data;
        SaleDto = responseS.Data;
        return RedirectToPage("./AddCategoryPayment");
    }
}