using System.ComponentModel.DataAnnotations;

namespace EasyWish.Domain.Class;

public class Wish
{
    public int? Id { get; set; }

    public int? WishListId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    [Range(0,10)]
    public int? Importance { get; set; }

    public string? Link { get; set; } 

    public DateTime? Created { get; set; }

    /// <summary>
    /// Id пользователя который забронировал дарить подарок
    /// </summary>
    public int? IdReserved { get; set; } 

    public User? Reserved { get; set; } 

    /// <summary>
    /// Поле чтобы пользователь мог помечать какой подарок он уже купил или получил
    /// </summary>
    public bool? IsDone { get; set; } 
}
