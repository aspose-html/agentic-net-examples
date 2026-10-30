// Implement error handling for unsupported file extensions when loading documents for rendering.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Validate file extension
            string ext = System.IO.Path.GetExtension(inputPath);
            if (!string.Equals(ext, ".html", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(ext, ".htm", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException($"File extension '{ext}' is not supported. Only .html and .htm are allowed.");
            }

            // Load the HTML document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}