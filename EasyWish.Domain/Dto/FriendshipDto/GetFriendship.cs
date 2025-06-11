using EasyWish.Domain.Class;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyWish.Domain.Dto.FriendshipDto;

public class GetFriendship
{
    [ForeignKey(nameof(AppUser))]
    public int? InitiatorId { get; set; }

    [ForeignKey(nameof(AppUser))]
    public int? RecipientId { get; set; }

    public DateTime? CreatedAt { get; set; }
}