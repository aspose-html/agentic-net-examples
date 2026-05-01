// Set FontsSettings to include both system and custom font folders before rendering to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file and output PDF file paths
            string htmlPath = "input.html";
            string outputPdf = "output.pdf";

            // Font folders: system fonts and a custom folder
            string systemFonts = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string customFonts = @"C:\MyFonts";

            // Create a configuration object for the conversion
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Retrieve the user agent service to configure font handling
            Aspose.Html.Services.IUserAgentService service = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

            // Add both system and custom font folders to the lookup list
            service.FontsSettings.SetFontsLookupFolder(systemFonts);
            service.FontsSettings.SetFontsLookupFolder(customFonts);

            // Load the HTML document using the configured environment
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Prepare default PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert the HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}