﻿using EasyWish.Domain.Class;

namespace EasyWish.Domain.Dto.UserDto;

public class PutUser
{
    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
