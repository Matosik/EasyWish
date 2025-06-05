namespace EasyWish.Domain.Class;

public class WishList
{
    public int? Id { get; set; }

    public int? UserId { get; set; }

    public User? Owner {get; set; }

    public string? Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastModified { get; set; }

    public ICollection<Wish>? Wishes { get; set; }
}
