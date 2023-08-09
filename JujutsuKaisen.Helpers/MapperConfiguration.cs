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
        }
    }
}
