using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;

namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PromotionController : ControllerBase
{
    private readonly IPromotionService _promotionService;
    
    public PromotionController(IPromotionService promotionService)
    {
        _promotionService = promotionService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Promotion>>>> GetAll()
    {
        var response = new Response<List<PromotionDto>>
        {
            Data = await _promotionService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Promotion>>> Post([FromBody] PromotionDto promotionDto)
    {
        var response = new Response<PromotionDto>();
        if (await _promotionService.ExistByName(promotionDto.Name))
        {
            response.Errors.Add($"Promotion name {promotionDto.Name} already exists");
            return BadRequest(response);
        }

        response.Data = await _promotionService.SaveAsync(promotionDto);
        return Created($"/api/[controller]/{promotionDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<PromotionDto>>> GetById(int id)
    {
        var response = new Response<PromotionDto>();
        
        
        if (!await _promotionService.PromotionExist(id))
        {
            response.Errors.Add("Promotion Not Found");
            return NotFound(response);
        }
        
        response.Data = await _promotionService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<PromotionDto>>> Update([FromBody] PromotionDto promotionDto)
    {
        var response = new Response<PromotionDto>();

        if (!await _promotionService.PromotionExist(promotionDto.id))
        {
            response.Errors.Add("Promotion not Found");
                return NotFound(response);
        }

        if (await _promotionService.ExistByName(promotionDto.Name, promotionDto.id))
        {
            response.Errors.Add($"Promotion Name {promotionDto.Name} already exists");
            return BadRequest(response);
        }
        response.Data = await _promotionService.UpdateAsync(promotionDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _promotionService.PromotionExist(id))
        {
            response.Errors.Add("Promotion not Found");
            return NotFound(response);
        }
        
        response.Data = await _promotionService.DeleteAsync(id);
        return Ok(response);
    }
    
}