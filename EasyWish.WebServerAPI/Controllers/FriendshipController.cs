using AutoMapper;
using EasyWish.Domain.Class;
using EasyWish.Domain.Dto.FriendshipDto;
using EasyWish.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyWish.WebServerAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FriendshipController(IGenericRepository<Friendship> repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var friendships = await repository.GetAll();
        return Ok(mapper.Map<IEnumerable<GetFriendship>>(friendships));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) 
    {
        var friendship = await repository.GetById(id);
        if (friendship == null) return NotFound();
        return Ok(mapper.Map<GetFriendship>(friendship));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostFriendship friendshipDto)
    {
        if (friendshipDto == null) return BadRequest("Friendship cannot be null");
        var friendship = mapper.Map<Friendship>(friendshipDto);
        friendship.CreatedAt = DateTime.UtcNow;
        await repository.Create(friendship);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PutFriendship friendshipDto)
    {
        var friendship = await repository.GetById(id);
        if (friendship == null) return BadRequest("Friendship ID mismatch");
        if (friendshipDto == null) return BadRequest("Friendship cannot be null");
        friendship = mapper.Map(friendshipDto, friendship);
        await repository.Update(friendship);
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
