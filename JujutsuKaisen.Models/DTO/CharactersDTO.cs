namespace JujutsuKaisen.Models.DTO
{
    public class CharactersDTO
    {
        public int IdCharacter { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;

        // Propiedad para el nombre del clan
        public string ClanName { get; set; } = string.Empty;
    }
}
