// Set a custom font lookup folder using FontsSettings.SetFontsLookupFolder before rendering HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "input.html");
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><body><p style='font-family:CustomFont;'>Hello, world!</p></body></html>");
            }

            if (!Directory.Exists(fontsFolder))
            {
                Directory.CreateDirectory(fontsFolder);
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath, configuration);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);
            Console.WriteLine("Conversion completed. PDF saved to: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}