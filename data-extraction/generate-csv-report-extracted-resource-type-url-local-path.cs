// Generate a CSV report listing each extracted resource with its type, URL, and local path.

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
        try
        {
            // Define paths
            string inputHtml = "input.html";
            string outputHtml = "output.html";
            string resourceDirectory = "resources";
            string csvPath = "resources_report.csv";
            string sampleTextFile = "sample.txt";

            // Ensure resource directory exists
            Directory.CreateDirectory(resourceDirectory);

            // Create a sample text file to be referenced as a resource
            File.WriteAllText(sampleTextFile, "Hello, resource!");

            // Create a simple HTML file that references the sample text file
            string htmlContent = "<!DOCTYPE html><html><body><a href=\"sample.txt\">Sample Text</a></body></html>";
            File.WriteAllText(inputHtml, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Set up the custom resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);

            // Save the document using the resource handler to extract resources
            HTMLSaveOptions options = new HTMLSaveOptions();
            document.Save(resourceHandler, options);

            // Generate CSV report of extracted resources
            using (StreamWriter csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("Type,URL,LocalPath");
                foreach (Resource resource in resourceHandler.Resources)
                {
                    string type = resource.MimeType != null ? resource.MimeType.ToString() : "unknown";
                    string url = resource.OriginalUrl != null ? resource.OriginalUrl.ToString() : string.Empty;
                    string localPath = resource.OutputUrl != null ? resource.OutputUrl.ToString() : string.Empty;
                    csvWriter.WriteLine($"{type},{url},{localPath}");
                }
            }

            // Save the final HTML document (with updated resource URLs) to output path
            document.Save(outputHtml);

            Console.WriteLine("Resource extraction and CSV report generation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}