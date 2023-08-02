using Newtonsoft.Json;
using Store.Models.Model;
using Store.Repository.Service;
using System.Text;

namespace Store.Repository.Frontend
{
    public class ClanRespositoryFrontend : IClan
    {
        private readonly HttpClient _fetch;
        public ClanRespositoryFrontend(HttpClient http)
        {
            _fetch = http;
        }
        public async Task<List<Clan>> Clan_GETS()
        {
            try
            {
                var json = await _fetch.GetStringAsync("Clan");
                return JsonConvert.DeserializeObject<List<Clan>>(json)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio Un Error: {ex.Message}");
                return new List<Clan>();
            }
        }
        public async Task<Clan> Clan_GET(int id)
        {
            try
            {
                var json = await _fetch.GetStringAsync($"Clan/{id}");
                return JsonConvert.DeserializeObject<Clan>(json)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio Un Error: {ex.Message}");
                return new Clan();
            }
        }
        public async Task<Clan> Clan_POST(Clan clan)
        {
            try
            {
                var json = JsonConvert.SerializeObject(clan);

                var response = await _fetch.PostAsync($"Clan", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Clan>(data)!;
                }
                else
                {
                    return new Clan();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio Un Error: {ex.Message}");
                return new Clan();
            }
        }
        public async Task<bool> Clan_PUT(Clan clan, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(clan);
                var response = await _fetch.PutAsync($"Clan/{id}", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio Un Error: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> Clan_DELETE(int id)

        {
            try
            {
                var response = await _fetch.DeleteAsync($"Clan/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio Un Error: {ex.Message}");
                return false;
            }
        }
    }
}
