using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Models.Model;
using Store.Repository.Service;

namespace Store.Repository.Backend
{
    public class CharacterRepositoryBackend : ICharacters
    {
        private readonly ApplicationDB _context;

        public CharacterRepositoryBackend(ApplicationDB context)
        {
            _context = context;
        }

        public async Task<List<Characters>> Characters_GETS()
        {
            var query = await _context.Characters.ToListAsync();

            return query != null ? query : null!;
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

        public async Task<Characters> Character_GET(int id)
        {
            var query = await _context.Characters.Where(x => x.IdCharacter == id).FirstOrDefaultAsync();

            return query != null ? query : null!;
        }

        public async Task<Characters> Character_POST(Characters character)
        {
            var query = await _context.Characters.Where(x => x.FirstName == character.FirstName).FirstOrDefaultAsync();

            if (query == null)
            {
                _context.Characters.Add(character);
                await _context.SaveChangesAsync();
                return character;
            }
            else
            {
                return null!;
            }
        }

        public async Task<bool> Character_PUT(Characters character, int id)
        {
            var query = await _context.Characters.Where(x => x.IdCharacter == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.FirstName = character.FirstName;
                //query.LastName = character.LastName;
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