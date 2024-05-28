using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.User;

public class Delete : PageModel
{
    [BindProperty] public UserDto UserDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    private readonly IUserService _service;

    public Delete(IUserService service)
    {
        _service = service;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        UserDto = new UserDto();
        var response = await _service.GetById(id);
        UserDto = response.Data;

        if (UserDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(UserDto.id);
        return RedirectToPage("./Edit");
    }
}