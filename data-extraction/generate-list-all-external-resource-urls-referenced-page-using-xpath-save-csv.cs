// Generate a list of all external resource URLs referenced in a page using XPath and save to CSV.

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
            string inputHtml = Path.Combine(Environment.CurrentDirectory, "input.html");
            string outputHtml = Path.Combine(Environment.CurrentDirectory, "output.html");
            string resourceDirectory = Path.Combine(Environment.CurrentDirectory, "resources");
            string csvPath = Path.Combine(Environment.CurrentDirectory, "resources.csv");

            // Ensure directories exist
            Directory.CreateDirectory(resourceDirectory);

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputHtml))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""https://example.com/style.css"">
</head>
<body>
    <h1>Sample Page</h1>
    <img src=""https://example.com/image.png"" alt=""Sample Image"">
</body>
</html>";
                File.WriteAllText(inputHtml, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Set up resource handler to capture external resources
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save the document, which triggers resource handling
            document.Save(resourceHandler, options);

            // Write resources information to CSV
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

            // Save the processed HTML (optional)
            document.Save(outputHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}