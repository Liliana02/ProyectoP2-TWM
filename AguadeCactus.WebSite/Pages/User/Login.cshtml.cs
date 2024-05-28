using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.User;

public class Login : PageModel
{
    [BindProperty] public UserDto UserDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    public string ErrorMessage { get; set; }
    
    private readonly IUserService _service;

    public Login(IUserService service)
    {
        _service = service;
        UserDto = new UserDto();
    }
    public async Task<IActionResult> OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.LoginAsync(UserDto.UserName, UserDto.Password);
        if (response.Data != null)
        {
            return RedirectToPage("~/Index");
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            ErrorMessage = "Contraseña o usuario inválido.";
            return Page();
        }

        return Page();
    }
    
}