using System.ComponentModel.DataAnnotations.Schema;

namespace JujutsuKaisen.Models.DTO
{
    public class CharactersDTO
    {
        public int IdCharacter { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;
        public int IdClan { get; set; }
        [NotMapped]
        public string NameClan { get; set; } = string.Empty;
    }
}
