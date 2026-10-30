// Set FontsSettings to include both system and custom font folders before rendering to PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain the user agent service to configure font lookup folders
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

            // Add system font folder
            userAgent.FontsSettings.SetFontsLookupFolder(@"C:\Windows\Fonts");
            // Add custom font folder
            userAgent.FontsSettings.SetFontsLookupFolder(@"C:\MyCustomFonts");

            // Load HTML content (inline)
            string htmlContent = "<html><body><p>Hello, PDF with custom fonts!</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}