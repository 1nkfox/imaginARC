using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using RevitCopilot.Infrastructure;
using Xunit;

namespace RevitCopilot.Tests
{
    public class McpClientTests
    {
        [Fact]
        public async Task SendPrompt_ReturnsResponse()
        {
            var mock = new MockHttpMessageHandler();
            mock.When("/prompt").Respond("application/json", "{\"result\":\"ok\"}");
            var client = new HttpClient(mock) { BaseAddress = new System.Uri(McpClient.BaseUrl) };
            var mcp = new McpClient(client);

            var result = await mcp.SendPrompt("test");

            Assert.Contains("ok", result);
        }
    }
}
