// Modify response content to include additional JSON metadata via a custom handler.

using System;
using System.IO;
using System.Text.Json.Nodes;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CustomHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.Content == null)
            return;

        string json = context.Response.Content.ReadAsString();
        try
        {
            JsonNode node = JsonNode.Parse(json);
            node["metadata"] = "added";
            string newJson = node.ToJsonString();
            Console.WriteLine(newJson);
        }
        catch
        {
            // Ignore non-JSON responses
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample files
            string htmlPath = "sample.html";
            string jsonPath = "data.json";
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><script src=\"data.json\"></script></head><body></body></html>");
            File.WriteAllText(jsonPath, "{\"name\":\"Test\"}");

            // Configure Aspose.HTML and add custom handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomHandler());

            // Load HTML document using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}