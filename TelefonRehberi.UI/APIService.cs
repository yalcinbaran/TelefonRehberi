using TelefonRehberi.Shared;

namespace TelefonRehberi.UI
{
    public class APIService
    {
        private readonly HttpClient _httpClient;

        public APIService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalApi");
        }

        public async Task<Kisi?> GetKisiByIdAsync(long id)
        {
            var response = await _httpClient.GetAsync($"api/Read/GetById/{id}");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<Kisi>();
            return data;
        }

        public async Task<List<Kisi>> GetTumKisilerAsync()
        {
            var response = await _httpClient.GetAsync("api/Read/GetAll");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Kisi>>();
            return data ?? new List<Kisi>();
        }

        public async Task<List<MenuClass>> GetAllMenuAsync()
        {
            var response = await _httpClient.GetAsync("api/Read/GetAllMenu");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<MenuClass>>();
            return data ?? new List<MenuClass>();
        }

        public async Task<long> KisiEkleAsync(Kisi kisi)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Create/KisiEkle", kisi);
            response.EnsureSuccessStatusCode();
            var id = await response.Content.ReadFromJsonAsync<long>();
            return id;
        }

        public async Task<long> KisiGuncelleAsync(Kisi kisi)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Update/KisiGuncelle", kisi);
            response.EnsureSuccessStatusCode();
            var id = await response.Content.ReadFromJsonAsync<long>();
            return id;
        }

        public async Task<bool> SilAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"api/Delete/KisiSil/{id}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
