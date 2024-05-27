using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages.User;

public class EditV : PageModel
{
    [BindProperty] public UserDto UserDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IUserService _service;

    public EditV(IUserService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        UserDto = new UserDto();

        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            UserDto = response.Data;
        }

        if (UserDto == null)
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

        Response<UserDto> response;
        if (UserDto.id > 0)
        {
            //Actualización
            response = await _service.UpdateAsync(UserDto);
        }
        else
        {
            //Insercción
            response = await _service.SaveAsync(UserDto);
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        UserDto = response.Data;
        return RedirectToPage("./Edit");
    }
}