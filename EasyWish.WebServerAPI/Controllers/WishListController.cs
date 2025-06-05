using AutoMapper;
using EasyWish.Domain.Class;
using EasyWish.Domain.Dto.DtoWishList;
using EasyWish.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyWish.WebServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishListController(IGenericRepository<WishList> repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var wishLists = await repository.GetAll();
        return Ok(mapper.Map<IEnumerable<GetWishList>>(wishLists));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var wishList = await repository.GetById(id);
        if (wishList == null) return NotFound();
        return Ok(mapper.Map<GetWishList>(wishList));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostWishList wishListDto)
    {
        if (wishListDto == null) return BadRequest("WishList cannot be null");
        var wishList = mapper.Map<WishList>(wishListDto);
        wishList.Created = DateTime.UtcNow;
        wishList.LastModified = DateTime.UtcNow;
        if (wishList.UserId == null) return BadRequest("User ID cannot be null");
        await repository.Create(wishList);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PutWishList wishListDto)
    {
        var wishList = await repository.GetById(id);
        if (wishList == null) return BadRequest("WishList ID mismatch");
        if (wishListDto == null) return BadRequest("WishList cannot be null");
        wishList = mapper.Map(wishListDto, wishList);
        await repository.Update(wishList);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repository.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}

