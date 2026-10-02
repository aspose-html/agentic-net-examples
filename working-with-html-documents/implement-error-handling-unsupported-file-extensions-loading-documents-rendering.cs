// Implement error handling for unsupported file extensions when loading documents for rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Validate file extension
            string extension = Path.GetExtension(inputPath);
            if (!string.Equals(extension, ".html", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(extension, ".htm", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException($"Unsupported file extension '{extension}'. Only .html and .htm are supported.");
            }

            // Load the HTML document with default configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF successfully created at '{Path.GetFullPath(outputPath)}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}