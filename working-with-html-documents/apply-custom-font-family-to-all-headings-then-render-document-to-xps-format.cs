// Apply a custom font family to all headings, then render the document to XPS format.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and set custom stylesheet for headings
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "h1, h2, h3, h4, h5, h6 { font-family: 'Comic Sans MS'; }";

            // Sample HTML content with headings
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Heading 1</h1><h2>Heading 2</h2><p>Paragraph text.</p></body></html>";

            // Load HTML document from inline content using the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration);

            // Set XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Output file path
            string outputPath = "output.xps";

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion to XPS completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}