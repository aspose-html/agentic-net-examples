// Export a loaded HTML document to PDF while embedding custom fonts specified in CSS.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source HTML, custom fonts folder, and output PDF
            string htmlPath = "input.html";
            string fontsFolder = "fonts";
            string pdfPath = "output.pdf";

            // Create a configuration object for the conversion process
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Retrieve the user agent service to configure font lookup
            Aspose.Html.Services.IUserAgentService userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document using the configured settings
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Convert the HTML document to PDF, embedding the custom fonts
            Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}