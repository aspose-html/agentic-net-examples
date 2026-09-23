// Store extracted resource metadata such as URL and size in a JSON file for later analysis.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;

class MyResourceHandler : Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler
{
    public List<Aspose.Html.Saving.Resource> Resources = new List<Aspose.Html.Saving.Resource>();
    public MyResourceHandler(string directory) : base(directory) { }
    public override void HandleResource(Aspose.Html.Saving.Resource resource, Aspose.Html.Saving.ResourceHandlingContext context)
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
            // Define paths
            string sampleHtmlPath = "sample.html";
            string outputHtmlPath = "output.html";
            string resourceDirectory = "resources";
            string jsonPath = "resources.json";

            // Ensure resource directory exists
            Directory.CreateDirectory(resourceDirectory);

            // Create a minimal HTML file with an external image
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1><img src=\"https://example.com/image.png\" alt=\"Sample Image\"/></body></html>";
            File.WriteAllText(sampleHtmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sampleHtmlPath);

            // Set up resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);

            // Save the document and extract resources
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(resourceHandler, options);

            // Prepare metadata list
            var metadata = new List<object>();
            foreach (Aspose.Html.Saving.Resource resource in resourceHandler.Resources)
            {
                string url = resource.OriginalUrl != null ? resource.OriginalUrl.ToString() : string.Empty;
                string localPath = resource.OutputUrl != null ? resource.OutputUrl.ToString() : string.Empty;
                long size = 0;
                if (!string.IsNullOrEmpty(localPath) && File.Exists(localPath))
                {
                    size = new FileInfo(localPath).Length;
                }
                metadata.Add(new { Url = url, LocalPath = localPath, Size = size });
            }

            // Serialize metadata to JSON
            string json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);

            // Save the final HTML (optional)
            document.Save(outputHtmlPath);

            Console.WriteLine("Resource metadata saved to " + jsonPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}