
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

    [ForeignKey(nameof(User))]
    public int? InitiatorId { get; set; }

    [ForeignKey(nameof(User))]
    public int? RecipientId { get; set; }
    public StatusResponse? Status { get; set;} 

    public DateTime? CreatedAt { get; set; }

    public User? Initiator { get; set; }

    public User? Recipient { get; set; }

    /// <summary>
    /// Нормализованое поле UserAId = min(InitiatorId, RecipientId)
    /// </summary>
    public int? UserAId { get; set; }

    /// <summary>
    /// Нормализованое поле UserBId = max(InitiatorId, RecipientId)
    /// </summary>
    public int? UserBId { get; set; }
}
