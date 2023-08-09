using AutoMapper;
using JujutsuKaisen.Models.DTO;
using JujutsuKaisen.Models.Model;

namespace JujutsuKaisen.Helpers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<CharactersDTO, Characters>();
            CreateMap<Characters, CharactersDTO>().ForMember(dest => dest.NameClan, opt => opt.MapFrom(src => src.Clan.ClanName));

            CreateMap<ClanDTO, Clan>();
            CreateMap<Clan, ClanDTO>();
        }
    }
}
