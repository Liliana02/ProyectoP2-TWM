using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;

namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;
    
    public PaymentMethodController(IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<PaymentMethod>>>> GetAll()
    {
        var response = new Response<List<PaymentMethodDto>>
        {
            Data = await _paymentMethodService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<PaymentMethod>>> Post([FromBody] PaymentMethodDto paymentMethodDto)
    {
        var response = new Response<PaymentMethodDto>
        {
            Data = await _paymentMethodService.SaveAsync(paymentMethodDto)
        };
        
        
        return Created($"/api/[controller]/{paymentMethodDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<PaymentMethodDto>>> GetById(int id)
    {
        var response = new Response<PaymentMethodDto>();
        
        
        if (!await _paymentMethodService.PaymentMethodExist(id))
        {
            response.Errors.Add("Payment Method Not Found");
            return NotFound(response);
        }
        
        response.Data = await _paymentMethodService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<PaymentMethodDto>>> Update(int id, [FromBody] 
        PaymentMethodDto paymentMethodDto)
    {
        var response = new Response<PaymentMethodDto>();

        if (!await _paymentMethodService.PaymentMethodExist(id))
        {
            response.Errors.Add("Payment Method not Found");
                return NotFound(response);
        }

        paymentMethodDto.id = id;
        response.Data = await _paymentMethodService.UpdateAsync(paymentMethodDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _paymentMethodService.PaymentMethodExist(id))
        {
            response.Errors.Add("Payment Method not Found");
            return NotFound(response);
        }
        
        response.Data = await _paymentMethodService.DeleteAsync(id);
        return Ok(response);
    }
    
}