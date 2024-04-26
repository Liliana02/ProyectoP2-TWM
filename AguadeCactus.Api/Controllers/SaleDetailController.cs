using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;

namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SaleDetailController : ControllerBase
{
    private readonly ISaleDetailService _saleDetailService;
    
    public SaleDetailController(ISaleDetailService saleDetailService)
    {
        _saleDetailService = saleDetailService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<SaleDetail>>>> GetAll()
    {
        var response = new Response<List<SaleDetailDto>>
        {
            Data = await _saleDetailService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<SaleDetail>>> Post([FromBody] SaleDetailDto saleDetailDto)
    {
        var response = new Response<SaleDetailDto>
        {
            Data = await _saleDetailService.SaveAsync(saleDetailDto)
        };
        
        
        return Created($"/api/[controller]/{saleDetailDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<SaleDetailDto>>> GetById(int id)
    {
        var response = new Response<SaleDetailDto>();
        
        
        if (!await _saleDetailService.SaleDetailExist(id))
        {
            response.Errors.Add("SaleDetail Not Found");
            return NotFound(response);
        }
        
        response.Data = await _saleDetailService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<SaleDetailDto>>> Update(int id, [FromBody] SaleDetailDto saleDetailDto)
    {
        var response = new Response<SaleDetailDto>();

        if (!await _saleDetailService.SaleDetailExist(id))
        {
            response.Errors.Add("SaleDetail not Found");
                return NotFound(response);
        }

        saleDetailDto.id = id;
        response.Data = await _saleDetailService.UpdateAsync(saleDetailDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _saleDetailService.SaleDetailExist(id))
        {
            response.Errors.Add("SaleDetail not Found");
            return NotFound(response);
        }
        
        response.Data = await _saleDetailService.DeleteAsync(id);
        return Ok(response);
    }
    
}