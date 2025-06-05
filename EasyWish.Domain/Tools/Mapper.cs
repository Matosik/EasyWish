using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyWish.Domain.Class;
using EasyWish.Domain.Dto.DtoWishList;
using EasyWish.Domain.Dto.UserDto;


namespace EasyWish.Domain.Tools;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, GetUser>().ReverseMap();
        CreateMap<User, PostUser>().ReverseMap();
        CreateMap<User, PutUser>().ReverseMap();

        CreateMap<WishList, GetWishList>().ReverseMap();
        CreateMap<WishList, PostWishList>().ReverseMap();
        CreateMap<WishList, PutWishList>().ReverseMap();

    }
}
