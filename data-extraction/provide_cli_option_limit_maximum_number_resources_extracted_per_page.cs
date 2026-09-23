// Provide a CLI option to limit the maximum number of resources extracted per page.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;

class MyResourceHandler : FileSystemResourceHandler
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
            // Parse CLI option for max handling depth (default 5)
            int maxDepth = 5;
            if (args.Length > 0 && int.TryParse(args[0], out int parsed))
            {
                maxDepth = parsed;
            }

            // Define paths
            string inputHtml = "input.html";
            string resourceDirectory = "extracted_resources";
            string csvPath = "resources.csv";

            // Ensure input HTML exists
            if (!File.Exists(inputHtml))
            {
                File.WriteAllText(inputHtml, "<html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><img src=\"image.png\"/></body></html>");
            }

            // Create output directory
            Directory.CreateDirectory(resourceDirectory);

            // Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Create custom resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);

            // Configure save options with max handling depth
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = maxDepth;

            // Save document and extract resources
            document.Save(resourceHandler, options);

            // Write CSV report
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

            Console.WriteLine($"Resources extracted with MaxHandlingDepth={maxDepth}. CSV report saved to '{csvPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}