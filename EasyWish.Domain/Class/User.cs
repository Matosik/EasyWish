namespace EasyWish.Domain.Class;

public class User
{
    public int Id { get; set; }
    public DateTime Registration { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<WishList> Lists { get; set; } = new List<WishList>();
    public List<User> Friends { get; set; } = new List<User>();
}