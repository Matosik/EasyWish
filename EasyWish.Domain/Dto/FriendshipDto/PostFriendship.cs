using EasyWish.Domain.Class;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyWish.Domain.Dto.FriendshipDto;

public class PostFriendship
{
    [ForeignKey(nameof(User))]
    public int? InitiatorId { get; set; }

    [ForeignKey(nameof(User))]
    public int? RecipientId { get; set; }
    public StatusResponse? Status { get; set; }
}
