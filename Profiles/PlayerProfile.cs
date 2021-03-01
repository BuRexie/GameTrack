using AutoMapper;
using GameTrack.Dtos;
using GameTrack.Models;

namespace GameTrack.Profiles
{
  public class PlayerProfile : Profile
  {
    public PlayerProfile()
    {
      CreateMap<Player, PlayerReadDto>();
      CreateMap<PlayerCreateDto, Player>();
    }
  }
}
