namespace EasyWish.Domain.Class;

public class Wish
{
    public int Id { get; set; }
    public int WishListId { get; set; }
    public required string Name { get; set; }
    public decimal? Price { get; set; }
    public byte Importance { get; set; } // 0 = low 10 = high
    public string? Link { get; set; } 
    public DateTime Created { get; set; }
    public int? IdReserved { get; set; } // 0 = not reserved, > 0 = user id of reserver
}
