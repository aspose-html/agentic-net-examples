// Implement error handling for unsupported file extensions when loading documents for rendering.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            string ext = System.IO.Path.GetExtension(inputPath);
            if (!string.Equals(ext, ".html", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(ext, ".htm", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException($"File extension '{ext}' is not supported.");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration);
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}