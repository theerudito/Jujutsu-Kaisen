using Store.Models.Model;

namespace Store.Repository.Service
{
    public interface IClan
    {
        Task<List<Clan>> Clan_GETS();
        Task<Clan> Clan_GET(int id);
        Task<Clan> Clan_POST(Clan clan);
        Task<bool> Clan_PUT(Clan clan, int id);
        Task<bool> Clan_DELETE(int id);
    }
}
