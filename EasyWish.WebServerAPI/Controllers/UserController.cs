using EasyWish.Domain.Repository;
using EasyWish.Domain.Dto.UserDto;
using EasyWish.Domain.Class;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace EasyWish.WebServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IGenericRepository<AppUser> repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() // НЕ выводит список друзей и список WishList
    {
        var users = await repository.GetAll();
        return Ok(mapper.Map<IEnumerable<GetUser>>(users));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) // НЕ выводит список друзей и список WishList
    {
        var user = await repository.GetById(id);
        if (user == null) return NotFound();
        return Ok(mapper.Map<GetUser>(user));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostUser userDto)
    {
        if (userDto == null) return BadRequest("User cannot be null");
        var user = mapper.Map<AppUser>(userDto);
        user.Registration = DateTime.UtcNow;
        await repository.Create(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PutUser userDto)
    {
        var user = await repository.GetById(id);
        if (user == null) return BadRequest("User ID mismatch");
        if (userDto == null) return BadRequest("User cannot be null");
        user = mapper.Map(userDto, user);
        await repository.Update(user);
        return NoContent();
    }
        
    [HttpDelete("{id}")] // НЕ Удаляет с связанными данными 
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repository.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
