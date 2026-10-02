// Set FontsSettings to include both system and custom font folders before rendering to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><p>Hello, Aspose.HTML!</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Output PDF path
            string pdfPath = "output.pdf";

            // Create configuration and set font lookup folders
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService service = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            service.FontsSettings.SetFontsLookupFolder(@"C:\Windows\Fonts");          // System fonts
            service.FontsSettings.SetFontsLookupFolder(@"C:\MyCustomFonts");        // Custom fonts

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Set PDF save options (optional customizations can be added here)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}