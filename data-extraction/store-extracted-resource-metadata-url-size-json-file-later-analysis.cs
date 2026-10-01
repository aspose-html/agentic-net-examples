// Store extracted resource metadata such as URL and size in a JSON file for later analysis.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;

class MyResourceHandler : FileSystemResourceHandler
{
    public List<Resource> Resources = new List<Resource>();

    public MyResourceHandler(string directory) : base(directory) { }

    public override void HandleResource(Resource resource, ResourceHandlingContext context)
    {
        Resources.Add(resource);
        base.HandleResource(resource, context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputHtml = "sample.html";
            if (!File.Exists(inputHtml))
            {
                File.WriteAllText(inputHtml, "<html><head><title>Test</title></head><body><img src=\"https://example.com/image.png\" /></body></html>");
            }

            string outputHtml = "output.html";
            string resourceDirectory = "resources";
            string jsonPath = "resources.json";

            Directory.CreateDirectory(resourceDirectory);

            HTMLDocument document = new HTMLDocument(inputHtml);
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            HTMLSaveOptions options = new HTMLSaveOptions();

            document.Save(resourceHandler, options);
            document.Save(outputHtml);

            JsonArray jsonArray = new JsonArray();

            foreach (Resource res in resourceHandler.Resources)
            {
                string type = res.MimeType != null ? res.MimeType.ToString() : "unknown";
                string url = res.OriginalUrl != null ? res.OriginalUrl.ToString() : "";
                string localPath = res.OutputUrl != null ? res.OutputUrl.ToString() : "";
                long size = 0;
                if (!string.IsNullOrEmpty(localPath) && File.Exists(localPath))
                {
                    size = new FileInfo(localPath).Length;
                }

                JsonObject obj = new JsonObject
                {
                    ["Type"] = type,
                    ["URL"] = url,
                    ["LocalPath"] = localPath,
                    ["Size"] = size
                };
                jsonArray.Add(obj);
            }

            File.WriteAllText(jsonPath, jsonArray.ToJsonString());

            Console.WriteLine("Resources metadata saved to " + jsonPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}