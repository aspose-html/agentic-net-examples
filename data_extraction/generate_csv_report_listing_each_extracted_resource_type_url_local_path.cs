// Generate a CSV report listing each extracted resource with its type, URL, and local path.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;

namespace HtmlResourceCsvReport
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input HTML file path
                string inputHtml = "input.html";

                // Output HTML file path
                string outputHtml = "output.html";

                // Directory where extracted resources will be saved
                string resourceDirectory = "resources";

                // CSV report path
                string csvPath = "resources_report.csv";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputHtml);

                // Create custom resource handler to collect resource metadata
                ResourceHandler resourceHandler = new ResourceHandler(resourceDirectory);

                // Save the document using the resource handler
                HTMLSaveOptions options = new HTMLSaveOptions();
                document.Save(resourceHandler, options);

                // Generate CSV report from collected resources
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

                // Save the main HTML file
                document.Save(outputHtml);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Custom handler that records each processed resource
    class ResourceHandler : FileSystemResourceHandler
    {
        public System.Collections.Generic.List<Resource> Resources = new System.Collections.Generic.List<Resource>();

        public ResourceHandler(string directory) : base(directory) { }

        public override void HandleResource(Resource resource, ResourceHandlingContext context)
        {
            Resources.Add(resource);
            base.HandleResource(resource, context);
        }
    }
}