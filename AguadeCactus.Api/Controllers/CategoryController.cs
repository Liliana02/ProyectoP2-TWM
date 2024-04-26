using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;


namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Category>>>> GetAll()
    {
        var response = new Response<List<CategoryDto>>
        {
            Data = await _categoryService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Category>>> Post([FromBody] CategoryDto categoryDto)
    {
        var response = new Response<CategoryDto>
        {
            Data = await _categoryService.SaveAsync(categoryDto)
        };
        
        
        return Created($"/api/[controller]/{categoryDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CategoryDto>>> GetById(int id)
    {
        var response = new Response<CategoryDto>();
        
        
        if (!await _categoryService.CategoryExist(id))
        {
            response.Errors.Add("Category Not Found");
            return NotFound(response);
        }
        
        response.Data = await _categoryService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<CategoryDto>>> Update(int id, [FromBody] CategoryDto categoryDto)
    {
        var response = new Response<CategoryDto>();

        if (!await _categoryService.CategoryExist(id))
        {
            response.Errors.Add("Category not Found");
                return NotFound(response);
        }

        categoryDto.id = id;
        response.Data = await _categoryService.UpdateAsync(categoryDto);
        return Ok(response);
    }
    

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _categoryService.CategoryExist(id))
        {
            response.Errors.Add("Category not Found");
            return NotFound(response);
        }
        
        response.Data = await _categoryService.DeleteAsync(id);
        return Ok(response);
    }
    
}