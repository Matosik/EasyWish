namespace EasyWish.Domain.Class;

public class User
{
    public int? Id { get; set; }

    public DateTime? Registration { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
    
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public ICollection<WishList>? Lists { get; set; }

    public ICollection<Friendship>? Friends { get; set; } 
}