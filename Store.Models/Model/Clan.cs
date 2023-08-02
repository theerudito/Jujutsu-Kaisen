using System.ComponentModel.DataAnnotations;

namespace Store.Models.Model
{
    public class Clan
    {
        [Key]
        public int IdClan { get; set; }
        public string ClanName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
