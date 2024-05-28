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
    
    private readonly IUserService _service;
    public async Task<IActionResult> OnGet()
    {
        return Page();
    }

    
}