using JujutsuKaisen.Database;
using JujutsuKaisen.Models.Model;
using JujutsuKaisen.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace JujutsuKaisen.Repository.Backend
{
    public class ClanRepositoryBackend : IClan
    {
        private readonly ApplicationDB _context;
        public ClanRepositoryBackend(ApplicationDB context)
        {
            _context = context;
        }

        async Task<List<Clan>> IClan.Clan_GETS()
        {
            var query = await _context.Clan.ToListAsync();
            return query != null
                ? query!
                : null!;
        }

        public async Task<Clan> Clan_GET(int id)
        {
            var query = await _context.Clan.Where(x => x.IdClan == id).FirstOrDefaultAsync();
            return query != null
                ? query!
                : null!;
        }
        public async Task<Clan> Clan_POST(Clan clan)
        {
            var query = await _context.Clan.Where(x => x.ClanName == clan.ClanName).FirstOrDefaultAsync();

            if (query == null)
            {
                _context.Clan.Add(clan);
                await _context.SaveChangesAsync();
                return clan;
            }
            else
            {
                return null!;
            }
        }
        public async Task<bool> Clan_PUT(Clan clan, int id)
        {
            var query = await _context.Clan.Where(x => x.IdClan == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.ClanName = clan.ClanName;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> Clan_DELETE(int id)
        {
            var query = await _context.Clan.FindAsync(id);

            if (query == null)
            {
                return false;
            }
            else
            {
                _context.Clan.Remove(query);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
