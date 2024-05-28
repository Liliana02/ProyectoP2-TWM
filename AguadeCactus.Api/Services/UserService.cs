using AguadeCactus.Api.Dto;
using AguadeCactus.Api.Repositories.Interfaces;
using AguadeCactus.Api.Services.Interfaces;
using AguadeCactus.Core.Entities;

namespace AguadeCactus.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> UserExist(int id)
    {
        var user = await _userRepository.GetById(id);
        return (user != null);
    }

    public async Task<UserDto> SaveAsync(UserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            LastName = userDto.LastName,
            UserName = userDto.UserName,
            Password = userDto.Password,
            Rol = userDto.Rol,
            Gender = userDto.Gender,
            Age = userDto.Age,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        user = await _userRepository.SaveAsync(user);
        userDto.id = user.id;

        return userDto;
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        var user = await _userRepository.GetById(userDto.id);
        
        if (user == null)
            throw new Exception("User Not Found");
        
        user.Name = userDto.Name;
        user.LastName = userDto.LastName;
        user.UserName = userDto.UserName;
        user.Password = userDto.Password;
        user.Rol = userDto.Rol;
        user.Gender = userDto.Gender;
        user.Age = userDto.Age;
        user.UpdatedBy = "";
        user.UpdatedDate = DateTime.Now;
        await _userRepository.UpdateAsync(user);
        
        return userDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var usersDto =
            users.Select(c => new UserDto(c)).ToList();
        return usersDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user == null)
            throw new Exception("User not Found");
        
        var userDto = new UserDto(user);
        return userDto;
    }

    public async Task<bool> ExistByName(string name, int id = 0)
    {
        var user = await _userRepository.GetByName(name, id);
        return user != null;
    }

    public async Task<UserDto> LoginAsync(string UserName, string Password)
    {
        var user = await _userRepository.GetLogin(UserName, Password);
        if (user == null || user.Password != Password)
        {
            throw new Exception("User or password incorrect");
        }

        return new UserDto(user);
    }
}