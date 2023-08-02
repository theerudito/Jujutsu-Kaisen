using Store.Models.Model;

namespace Store.Repository.Service
{
    public interface ICharacters
    {
        public Task<List<Characters>> Characters_GETS();

        public Task<Characters> Character_GET(int id);

        public Task<Characters> Character_POST(Characters character);

        public Task<bool> Character_PUT(Characters character, int id);

        public Task<bool> Character_DELETE(int id);
    }
}