﻿using EasyWish.Domain.Class;


namespace EasyWish.Domain.Dto.UserDto;

public class GetUser
{
    public DateTime? Registration { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public ICollection<WishList>? Lists { get; set; }

    public ICollection<Friendship>? Friends { get; set; }
}
