// Modify response content to include additional JSON metadata via a custom handler.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using System.Text.Json.Nodes;

public class JsonMetadataHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.Content == null)
            return;
        string jsonContent = context.Response.Content.ReadAsString();
        try
        {
            JsonNode jsonNode = JsonNode.Parse(jsonContent);
            jsonNode["metadata"] = "added";
            string newJson = jsonNode.ToJsonString();
            System.Console.WriteLine(newJson);
        }
        catch
        {
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new JsonMetadataHandler());

            string htmlContent = "<html><body><h1>Hello</h1></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                System.Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}