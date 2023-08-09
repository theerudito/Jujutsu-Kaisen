using System.ComponentModel.DataAnnotations;

namespace JujutsuKaisen.Models.Model
{
    public class Characters
    {
        [Key]
        public int IdCharacter { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;

        // Clave foránea para la relación con Clan
        public int? IdClan { get; set; }
        public virtual Clan? Clan { get; set; }
    }
}