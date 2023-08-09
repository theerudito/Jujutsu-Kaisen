using System.ComponentModel.DataAnnotations;

namespace JujutsuKaisen.Models.Model
{
    public class Clan
    {
        [Key]
        public int IdClan { get; set; }
        public string? ClanName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public virtual ICollection<Characters>? Characters { get; set; } = new List<Characters>();
    }
}
