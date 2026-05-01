// Set custom fonts folder, load HTML using local font files, and verify text renders with those fonts.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string fontsFolder = @"C:\MyFonts";
            string htmlPath = @"C:\Input\sample.html";
            string outputPdf = @"C:\Output\result.pdf";

            Configuration configuration = new Configuration();
            IUserAgentService service = configuration.GetService<IUserAgentService>();
            service.FontsSettings.SetFontsLookupFolder(fontsFolder);

            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertHTML(document, options, outputPdf);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}