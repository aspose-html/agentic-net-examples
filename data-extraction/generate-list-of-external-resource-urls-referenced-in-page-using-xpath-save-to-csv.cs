// Generate a list of all external resource URLs referenced in a page using XPath and save to CSV.

using System;
using System.IO;
using System.Collections.Generic;
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
            string inputHtml = "input.html";
            string outputHtml = "output.html";
            string resourceDirectory = "resources";
            string csvPath = "resources.csv";

            // Ensure resource directory exists
            if (!Directory.Exists(resourceDirectory))
                Directory.CreateDirectory(resourceDirectory);

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputHtml))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""https://example.com/style.css"">
</head>
<body>
    <img src=""https://example.com/image.png"" alt=""Sample Image"">
    <script src=""https://example.com/script.js""></script>
</body>
</html>";
                File.WriteAllText(inputHtml, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Set up resource handler to capture external resources
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save the document using the resource handler (this will download resources)
            document.Save(resourceHandler, options);

            // Write resource information to CSV
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

            // Save the processed HTML document
            document.Save(outputHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}