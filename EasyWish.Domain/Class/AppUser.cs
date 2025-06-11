using System.ComponentModel.DataAnnotations.Schema;

namespace EasyWish.Domain.Class;

public class AppUser
{
    public int? Id { get; set; }

    public DateTime? Registration { get; set; }

    public string? Nickname { get; set; } // уникальный никнейм

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public bool EmailConfirmed { get; set; } = false;
    
    public string? PasswordHash { get; set; }

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