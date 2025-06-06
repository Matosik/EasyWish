using EasyWish.Domain.Repository;
using EasyWish.Domain.Class;
using Microsoft.AspNetCore.Mvc;
using EasyWish.Domain.Dto.WishDto;
using AutoMapper;

namespace EasyWish.WebServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishController(IGenericRepository<Wish> repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var wishes = await repository.GetAll();
        return Ok(mapper.Map<IEnumerable<GetWish>>(wishes));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var wish = await repository.GetById(id);
        if (wish == null) return NotFound();
        return Ok(mapper.Map<GetWish>(wish));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostWish wishDto)
    {
        if (wishDto == null) return BadRequest("Wish cannot be null");
        if (wishDto.WishListId == null) return BadRequest("WishListId cannot be null");
        var wish = mapper.Map<Wish>(wishDto);
        wish.Created = DateTime.UtcNow;
        await repository.Create(wish);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PutWish wishDto)
    {
        var wish = await repository.GetById(id);
        if (wish == null) return BadRequest("Wish ID mismatch");
        if (wishDto == null) return BadRequest("Wish cannot be null");
        wish = mapper.Map(wishDto, wish);
        await repository.Update(wish);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repository.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
