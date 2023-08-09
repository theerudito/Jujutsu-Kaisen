using AutoMapper;
using JujutsuKaisen.Database;
using JujutsuKaisen.Models.DTO;
using JujutsuKaisen.Models.Model;
using JujutsuKaisen.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace JujutsuKaisen.Repository.Backend
{
    public class ClanRepositoryBackend : IClan
    {
        private readonly ApplicationDB _context;
        private readonly IMapper _mapper;
        public ClanRepositoryBackend(ApplicationDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<List<ClanDTO>> IClan.Clan_GETS()
        {
            var query = await _context.Clan.ToListAsync();

            return query != null
                 ? _mapper.Map<List<ClanDTO>>(query)
                : null!;
        }

        public async Task<ClanDTO> Clan_GET(int id)
        {
            var query = await _context.Clan.Where(x => x.IdClan == id).FirstOrDefaultAsync();

            return query != null
                ? _mapper.Map<ClanDTO>(query)
                : null!;
        }
        public async Task<Clan> Clan_POST(ClanDTO clan)
        {
            var query = await _context.Clan.Where(x => x.ClanName == clan.ClanName).FirstOrDefaultAsync();

            if (query == null)
            {
                var mappingClan = _mapper.Map<Clan>(clan);

                _context.Add(mappingClan);
                await _context.SaveChangesAsync();
                return mappingClan;
            }
            else
            {
                return null!;
            }
        }
        public async Task<bool> Clan_PUT(ClanDTO clan, int id)
        {
            var query = await _context.Clan.Where(x => x.IdClan == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.ClanName = clan.ClanName;
                query.Image = clan.Image;
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
