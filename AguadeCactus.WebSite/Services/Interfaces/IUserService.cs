using AguadeCactus.Api.Dto;
using AguadeCactus.Core.Http;

namespace AguadeCactus.WebSite.Services.Interfaces;

public interface IUserService
{
    Task<Response<List<UserDto>>> GetAllAsync();
    Task<Response<UserDto>> GetById(int id);
    Task<Response<UserDto>> SaveAsync(UserDto userDto);
    Task<Response<UserDto>> UpdateAsync(UserDto userDto);
    Task<Response<bool>> DeleteAsync(int id);
}