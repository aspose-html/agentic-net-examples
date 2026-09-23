// Generate a CSV report listing each extracted resource with its type, URL, and local path.

class MyResourceHandler : Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler
{
    public System.Collections.Generic.List<Aspose.Html.Saving.Resource> Resources = new System.Collections.Generic.List<Aspose.Html.Saving.Resource>();
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
            string csvPath = "resources_report.csv";

            // Ensure resource directory exists
            System.IO.Directory.CreateDirectory(resourceDirectory);

            // Create a minimal sample image file
            string sampleImagePath = "sample.png";
            if (!System.IO.File.Exists(sampleImagePath))
            {
                // Write a minimal PNG header (1x1 pixel transparent)
                byte[] pngHeader = new byte[] {
                    0x89,0x50,0x4E,0x47,0x0D,0x0A,0x1A,0x0A,
                    0x00,0x00,0x00,0x0D,0x49,0x48,0x44,0x52,
                    0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,
                    0x08,0x06,0x00,0x00,0x00,0x1F,0x15,0xC4,
                    0x89,0x00,0x00,0x00,0x0A,0x49,0x44,0x41,
                    0x54,0x78,0x9C,0x63,0x00,0x01,0x00,0x00,
                    0x05,0x00,0x01,0x0D,0x0A,0x2D,0xB4,0x00,
                    0x00,0x00,0x00,0x49,0x45,0x4E,0x44,0xAE,
                    0x42,0x60,0x82 };
                System.IO.File.WriteAllBytes(sampleImagePath, pngHeader);
            }

            // Create a minimal sample HTML file referencing the image
            if (!System.IO.File.Exists(inputHtml))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><img src=\"sample.png\" alt=\"Sample Image\"/></body></html>";
                System.IO.File.WriteAllText(inputHtml, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml);

            // Set up resource handler
            MyResourceHandler resourceHandler = new MyResourceHandler(resourceDirectory);
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save HTML and extract resources
            document.Save(resourceHandler, options);
            document.Save(outputHtml);

            // Generate CSV report
            using (System.IO.StreamWriter csvWriter = new System.IO.StreamWriter(csvPath, false))
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

            System.Console.WriteLine("Resource extraction and CSV report generation completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}