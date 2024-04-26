using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;

namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;
    
    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Sale>>>> GetAll()
    {
        var response = new Response<List<SaleDto>>
        {
            Data = await _saleService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Sale>>> Post([FromBody] SaleDto saleDto)
    {
        var response = new Response<SaleDto>
        {
            Data = await _saleService.SaveAsync(saleDto)
        };
        
        
        return Created($"/api/[controller]/{saleDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<SaleDto>>> GetById(int id)
    {
        var response = new Response<SaleDto>();
        
        
        if (!await _saleService.SaleExist(id))
        {
            response.Errors.Add("Sale Not Found");
            return NotFound(response);
        }
        
        response.Data = await _saleService.GetById(id);
        return Ok(response);
    }

    [HttpPut ("{id:int}")]
    public async Task<ActionResult<Response<SaleDto>>> Update(int id, [FromBody] SaleDto saleDto)
    {
        var response = new Response<SaleDto>();

        if (!await _saleService.SaleExist(id))
        {
            response.Errors.Add("Sale not Found");
                return NotFound(response);
        }

        saleDto.id = id;
        response.Data = await _saleService.UpdateAsync(saleDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _saleService.SaleExist(id))
        {
            response.Errors.Add("Sale not Found");
            return NotFound(response);
        }
        
        response.Data = await _saleService.DeleteAsync(id);
        return Ok(response);
    }
    
}