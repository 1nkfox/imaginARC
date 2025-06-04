using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RevitCopilot.Infrastructure
{
    public class McpClient
    {
        public const string BaseUrl = "https://example.com/mcp";
        private readonly HttpClient _httpClient;

        public McpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendPrompt(string prompt)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { prompt }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/prompt", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public Task ExecuteResponse(string response)
        {
            // Implement execution logic here
            return Task.CompletedTask;
        }
    }
}
