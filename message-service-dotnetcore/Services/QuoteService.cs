using System.Net.Http;
using System.Threading.Tasks;
using MessageService.Models;

namespace BillboardClient.Services
{
    public class QuoteService
    {
        private readonly HttpClient _httpClient;

        public QuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BillboardQuote> GetRandom()
        {
            var response = await _httpClient.GetAsync("/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<BillboardQuote>();
        }
    }
}