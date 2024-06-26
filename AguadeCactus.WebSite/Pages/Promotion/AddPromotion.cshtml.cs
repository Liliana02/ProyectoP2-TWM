﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;
using AguadeCactus.WebSite.Services;

namespace AguadeCactus.WebSite.Pages;

public class AddPromotion : PageModel
{
    [BindProperty] public PromotionDto PromotionDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    public List<PromotionDto> Promotions { get; set; }
    
    private readonly IPromotionService _service;

    public AddPromotion(IPromotionService service)
    {
        Promotions = new List<PromotionDto>();
        _service = service;
    }
    public async Task<IActionResult> OnGetId(int? id)
    {
        PromotionDto = new PromotionDto();

        if (id.HasValue)
        {
            var response = await _service.GetById(id.Value);
            PromotionDto = response.Data;
        }

        if (PromotionDto == null)
        {
            return Redirect("/Error");
        }


        return Page();
    }

    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Promotions = response.Data;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<PromotionDto> response;
        if (PromotionDto.id > 0)
        {
            //Actualización
            response = await _service.UpdateAsync(PromotionDto);
        }
        else
        {
            //Insercción
            response = await _service.SaveAsync(PromotionDto);
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            return Page();
        }

        PromotionDto = response.Data;
        return RedirectToPage("./AddPromotion");
    }
}