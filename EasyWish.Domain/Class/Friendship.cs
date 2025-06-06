
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyWish.Domain.Class;

public enum StatusResponse
{
    rejected,
    accepted,
    review
}
public class Friendship
{
    public int? Id { get; set; }

    public User? Initiator { get; set; }

    public User?  Recipient { get; set; }

    [ForeignKey(nameof(User))]
    public int? InitiatorId { get; set; }

    [ForeignKey(nameof(User))]
    public int? RecipientId { get; set; }
    public StatusResponse? Status { get; set;} 

    public DateTime? CreatedAt { get; set; }
}
