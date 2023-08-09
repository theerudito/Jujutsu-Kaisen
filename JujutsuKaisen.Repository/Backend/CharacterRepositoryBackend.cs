using AutoMapper;
using JujutsuKaisen.Database;
using JujutsuKaisen.Models.DTO;
using JujutsuKaisen.Models.Model;
using JujutsuKaisen.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace JujutsuKaisen.Repository.Backend
{
    public class CharacterRepositoryBackend : ICharacters
    {
        private readonly ApplicationDB _context;
        private readonly IMapper _mapper;

        public CharacterRepositoryBackend(ApplicationDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CharactersDTO>> Characters_GETS()
        {
            var query = await _context.Characters.Include(c => c.Clan).ToListAsync();

            return _mapper.Map<List<CharactersDTO>>(query);
        }

        public async Task<bool> Character_DELETE(int id)
        {
            var query = await _context.Characters.Where(x => x.IdCharacter == id).FirstOrDefaultAsync();

            if (query != null)
            {
                _context.Characters.Remove(query);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<CharactersDTO> Character_GET(int id)
        {
            var query = await _context.Characters
                .Include(c => c.Clan)
                .Where(x => x.IdCharacter == id).FirstOrDefaultAsync();

            return query != null ? _mapper.Map<CharactersDTO>(query) : null!;
        }

        public async Task<Characters> Character_POST(CharactersDTO character)
        {
            var query = await _context.Characters
                .Include(c => c.Clan)
                .Where(x => x.FirstName == character.FirstName)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var characterDTO = _mapper.Map<Characters>(character);

                _context.Characters.Add(characterDTO);

                await _context.SaveChangesAsync();

                return characterDTO;
            }
            else
            {
                return null!;
            }
        }

        public async Task<bool> Character_PUT(CharactersDTO character, int id)
        {
            var query = await _context.Characters
                .Include(c => c.Clan)
                .Where(x => x.IdCharacter == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.FirstName = character.FirstName;
                query.IdClan = character.IdClan;
                query.Age = character.Age;
                query.Image = character.Image;
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}