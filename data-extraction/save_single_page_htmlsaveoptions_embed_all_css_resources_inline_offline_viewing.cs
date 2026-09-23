// Save a single page with HTMLSaveOptions that embed all CSS resources inline for offline viewing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with external CSS reference
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><h1>Hello World</h1></body></html>";
            string cssContent = "h1 { color: red; }";

            // Prepare temporary files
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExample");
            Directory.CreateDirectory(tempDir);
            string htmlPath = Path.Combine(tempDir, "sample.html");
            string cssPath = Path.Combine(tempDir, "style.css");
            File.WriteAllText(htmlPath, htmlContent);
            File.WriteAllText(cssPath, cssContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure save options to embed resources (default behavior with sufficient handling depth)
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;

            // Save the document with embedded CSS for offline viewing
            string outputPath = Path.Combine(tempDir, "output.html");
            document.Save(outputPath, options);

            Console.WriteLine("HTML saved with embedded resources to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}