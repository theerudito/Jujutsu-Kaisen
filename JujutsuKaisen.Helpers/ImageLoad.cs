namespace JujutsuKaisen.Helpers
{
    public static class ImageLoad
    {
        public static string TOPNG(string base64)
        {
            return $"data:image/png;base64,{base64}";
        }
    }
}
