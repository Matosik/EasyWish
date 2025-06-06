using AutoMapper;
using EasyWish.Domain.Class;
using EasyWish.Domain.Dto.DtoWishList;
using EasyWish.Domain.Dto.UserDto;
using EasyWish.Domain.Dto.WishDto;
using EasyWish.Domain.Dto.FriendshipDto;


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

        CreateMap<Wish, GetWish>().ReverseMap();
        CreateMap<Wish, PostWish>().ReverseMap();
        CreateMap<Wish, PutWish>().ReverseMap();

        CreateMap<Friendship, GetFriendship>().ReverseMap();
        CreateMap<Friendship, PostFriendship>().ReverseMap();
        CreateMap<Friendship, PutFriendship>().ReverseMap();
    }
}
