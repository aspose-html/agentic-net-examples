// Generate a list of all external resource URLs referenced in a page using XPath and save to CSV.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using Aspose.Html;

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
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string inputHtml = "input.html";
            string outputHtml = "output.html";
            string resourceDirectory = "resources";
            string csvPath = "resources.csv";

            // Ensure directories exist
            if (!Directory.Exists(resourceDirectory))
                Directory.CreateDirectory(resourceDirectory);

            // Create a minimal sample HTML file with external resources
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""https://example.com/style.css"">
</head>
<body>
    <img src=""https://example.com/image.png"" alt=""Sample Image"">
    <script src=""https://example.com/script.js""></script>
</body>
</html>";
            File.WriteAllText(inputHtml, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Set up the custom resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save the document using the resource handler to capture external resources
            document.Save(resourceHandler, options);

            // Write captured resources to CSV
            using (StreamWriter csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("Type,URL,LocalPath");
                foreach (Aspose.Html.Saving.Resource resource in resourceHandler.Resources)
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}