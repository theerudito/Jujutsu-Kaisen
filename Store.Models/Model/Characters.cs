using System.ComponentModel.DataAnnotations;

namespace Store.Models.Model
{
    public class Characters
    {
        [Key]
        public int IdCharacter { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Age { get; set; }

        public int IdClan { get; set; }
        public Clan Clan { get; set; } = new Clan();
    }
}