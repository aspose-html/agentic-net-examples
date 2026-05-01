// Convert 900 pixel height to points and apply it to set paragraph spacing in PDF output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML file path and content with paragraph spacing set to 675 points (900px at 96 DPI)
            string htmlPath = "input.html";
            string htmlContent = "<html><body><p style=\"margin-bottom:675pt;\">Sample paragraph with spacing.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Create PDF save options (default settings)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF applying the paragraph spacing
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}