using EasyWish.Domain.Class;
using System.ComponentModel.DataAnnotations;

namespace EasyWish.Domain.Dto.WishDto;

public class GetWish
{
    public int? WishListId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    [Range(0, 10)]
    public int? Importance { get; set; }

    public string? Link { get; set; }

    public DateTime? Created { get; set; }

    public int? IdReserved { get; set; }

    public User? Reserved { get; set; }
}
