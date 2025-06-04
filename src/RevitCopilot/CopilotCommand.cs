using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using RevitCopilot.Infrastructure;

namespace RevitCopilot
{
    [Transaction(TransactionMode.Manual)]
    public class CopilotCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var httpClient = new HttpClient { BaseAddress = new Uri(McpClient.BaseUrl) };
            var client = new McpClient(httpClient);
            Task.Run(async () =>
            {
                string response = await client.SendPrompt("CreateWall 0 0 10 0 10");
                await client.ExecuteResponse(response);
            }).GetAwaiter().GetResult();

            TaskDialog.Show("Revit Copilot", "Command executed via MCP");
            return Result.Succeeded;
        }
    }
}
