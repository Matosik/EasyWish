using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace EasyWish.Domain.Class;

public class AppUser : IdentityUser<int>
{
    public DateTime? Registration { get; set; }

    public string? Nickname { get; set; } // уникальный никнейм

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? OAuthProvider { get; set; } // например: "google", "vk"
    public string? OAuthSubject { get; set; } // уникальный ID от провайдера

    public ICollection<WishList>? Lists { get; set; }

    public ICollection<Friendship>? SentFriendships { get; set; }

    public ICollection<Friendship>? ReceivedFriendships { get; set; }

    [NotMapped]
    public IEnumerable<Friendship> Friends =>
        (SentFriendships ?? Enumerable.Empty<Friendship>())
        .Concat(ReceivedFriendships ?? Enumerable.Empty<Friendship>());
}