using JujutsuKaisen.Models.DTO;
using JujutsuKaisen.Models.Model;

namespace JujutsuKaisen.Repository.Service
{
    public interface IClan
    {
        Task<List<ClanDTO>> Clan_GETS();
        Task<ClanDTO> Clan_GET(int id);
        Task<Clan> Clan_POST(ClanDTO clan);
        Task<bool> Clan_PUT(ClanDTO clan, int id);
        Task<bool> Clan_DELETE(int id);
    }
}
