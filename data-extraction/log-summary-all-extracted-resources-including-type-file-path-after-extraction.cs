// Log a summary of all extracted resources, including type and file path, after extraction.

using System;
using System.IO;
using System.Collections.Generic;
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
        string inputHtml = "input.html";
        string outputHtml = "output.html";
        string resourceDirectory = "resources";
        string logPath = "extraction_log.txt";

        try
        {
            // Ensure resource directory exists
            Directory.CreateDirectory(resourceDirectory);

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputHtml))
            {
                string sampleHtml = @"<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><img src='https://via.placeholder.com/150' alt='Sample Image'></body></html>";
                File.WriteAllText(inputHtml, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Set up the custom resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            HTMLSaveOptions options = new HTMLSaveOptions();

            // Save the document and extract resources
            document.Save(resourceHandler, options);

            // Log summary of extracted resources
            foreach (Resource resource in resourceHandler.Resources)
            {
                string type = resource.MimeType != null ? resource.MimeType.ToString() : "unknown";
                string localPath = resource.OutputUrl != null ? resource.OutputUrl.ToString() : string.Empty;
                File.AppendAllText(logPath, $"{type},{localPath}{Environment.NewLine}");
            }

            // Save the processed HTML
            document.Save(outputHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}