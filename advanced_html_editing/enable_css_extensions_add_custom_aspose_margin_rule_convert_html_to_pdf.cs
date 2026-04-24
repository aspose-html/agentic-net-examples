// Enable CSS extensions, add a custom -aspose- margin rule, then convert the HTML to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file and output PDF file paths
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Create configuration and enable custom CSS rule
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            IUserAgentService userAgent = config.GetService<IUserAgentService>();
            // Add custom -aspose- margin rule via user stylesheet
            userAgent.UserStyleSheet = "-aspose-margin: 10mm;";

            // Load HTML document with the configuration
            HTMLDocument document = new HTMLDocument(htmlPath, config);

            // Set PDF conversion options (default options)
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}