using TrsWebApp.Models;

namespace TrsWebApp.Services
{
    public class ContactInfoService
    {
        private readonly HttpClient _httpClient;

        public ContactInfoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ContactInfoApi");
        }

        public async Task<List<ContactInfo>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ContactInfo>>("ContactInfo")
                   ?? new List<ContactInfo>();
        }

        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ContactInfo>($"ContactInfo/{id}");
        }

        public async Task AddAsync(ContactInfo contact)
        {
            var response = await _httpClient.PostAsJsonAsync("ContactInfo", contact);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int id, ContactInfo contact)
        {
            var response = await _httpClient.PutAsJsonAsync($"ContactInfo/{id}", contact);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"ContactInfo/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
