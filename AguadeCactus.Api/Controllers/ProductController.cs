using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;

namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Product>>>> GetAll()
    {
        var response = new Response<List<ProductDto>>
        {
            Data = await _productService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Product>>> Post([FromBody] ProductDto productDto)
    {
        var response = new Response<ProductDto>();
        if (await _productService.ExistByName(productDto.Name))
        {
            response.Errors.Add($"Product name {productDto.Name} already exists");
            return BadRequest(response);
        }

        response.Data = await _productService.SaveAsync(productDto);
        return Created($"/api/[controller]/{productDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductDto>>> GetById(int id)
    {
        var response = new Response<ProductDto>();
        
        
        if (!await _productService.ProductExist(id))
        {
            response.Errors.Add("Product Not Found");
            return NotFound(response);
        }
        
        response.Data = await _productService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ProductDto>>> Update([FromBody] ProductDto productDto)
    {
        var response = new Response<ProductDto>();

        if (!await _productService.ProductExist(productDto.id))
        {
            response.Errors.Add("Product not Found");
                return NotFound(response);
        }

        if (await _productService.ExistByName(productDto.Name, productDto.id))
        {
            response.Errors.Add($"Product Name {productDto.Name} already exists");
            return BadRequest(response);
        }
        response.Data = await _productService.UpdateAsync(productDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _productService.ProductExist(id))
        {
            response.Errors.Add("Product not Found");
            return NotFound(response);
        }
        
        response.Data = await _productService.DeleteAsync(id);
        return Ok(response);
    }
    
}