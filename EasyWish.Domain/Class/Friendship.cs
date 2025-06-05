
namespace EasyWish.Domain.Class;

public class Friendship
{
    public int Id { get; set; }
    public User Initiator { get; set; }
    public User Recipient { get; set; }
    public int InitiatorId { get; set; }
    public int RecipientId { get; set; }
    public DateTime CreatedAt { get; set; }
}
