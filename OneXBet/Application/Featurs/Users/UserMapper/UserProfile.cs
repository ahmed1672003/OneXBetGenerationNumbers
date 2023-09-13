using AutoMapper;

namespace OneXBet.Application.Featurs.Users.UserMapper;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<RegisterUserVM, User>()
            .ForMember(dist => dist.LastUpdated, cfg => cfg.MapFrom(src => DateTime.Now));

        CreateMap<User, GetUserVM>();
    }
}
