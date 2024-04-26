using Microsoft.AspNetCore.Mvc;
using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;
using AguadeCactus.Core.Http;

namespace AguadeCactus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<User>>>> GetAll()
    {
        var response = new Response<List<UserDto>>
        {
            Data = await _userService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<User>>> Post([FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>
        {
            Data = await _userService.SaveAsync(userDto)
        };
        
        
        return Created($"/api/[controller]/{userDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int id)
    {
        var response = new Response<UserDto>();
        
        
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }
        
        response.Data = await _userService.GetById(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> Update(int id, [FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>();

        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User not Found");
                return NotFound(response);
        }

        userDto.id = id;
        response.Data = await _userService.UpdateAsync(userDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User not Found");
            return NotFound(response);
        }
        
        response.Data = await _userService.DeleteAsync(id);
        return Ok(response);
    }
    
}