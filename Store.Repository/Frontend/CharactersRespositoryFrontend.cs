using Newtonsoft.Json;
using Store.Models.Model;
using Store.Repository.Service;
using System.Text;

namespace Store.Repository.Frontend
{
    public class CharactersRespositoryFrontend : ICharacters
    {
        private readonly HttpClient _fetch;

        public CharactersRespositoryFrontend(HttpClient fetch)
        {
            _fetch = fetch;
        }

        public async Task<List<Characters>> Characters_GETS()
        {
            try
            {
                var response = await _fetch.GetAsync("Characters");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Characters>>(data)!;
                }
                else
                {
                    return new List<Characters>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los personajes: {ex.Message}");
                return new List<Characters>();
            }
        }

        public async Task<bool> Character_DELETE(int id)
        {
            try
            {
                var response = await _fetch.DeleteAsync($"Characters/{id}");

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
                Console.WriteLine($"Error al obtener los personajes: {ex.Message}");
                return false;
            }
        }

        public async Task<Characters> Character_GET(int id)
        {
            try
            {
                var response = await _fetch.GetAsync($"Characters/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Characters>(data)!;
                }
                else
                {
                    return new Characters();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los personajes: {ex.Message}");
                return new Characters();
            }
        }

        public async Task<Characters> Character_POST(Characters character)
        {
            try
            {
                var json = JsonConvert.SerializeObject(character);

                var response = await _fetch.PostAsync($"Characters", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Characters>(data)!;
                }
                else
                {
                    return new Characters();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los personajes: {ex.Message}");
                return new Characters();

            }

        }

        public async Task<bool> Character_PUT(Characters character, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(character);
                var response = await _fetch.PutAsync($"Characters/{id}", new StringContent(json, Encoding.UTF8, "application/json"));
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
                Console.WriteLine($"Error al obtener los personajes: {ex.Message}");
                return false;
            }
        }
    }
}