using EasyWish.Domain.Class;
using EasyWish.Domain.Dto.UserDto;

namespace EasyWish.Domain.Dto.DtoWishList;

public class GetWishList
{
    public int? UserId { get; set; } // Сюда наверное луже Dto-шку GetUser положить

    public string? Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastModified { get; set; }

    public ICollection<Wish>? Wishes { get; set; }
}
