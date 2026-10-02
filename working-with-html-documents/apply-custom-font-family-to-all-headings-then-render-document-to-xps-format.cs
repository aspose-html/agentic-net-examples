// Apply a custom font family to all headings, then render the document to XPS format.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            var configuration = new Aspose.Html.Configuration();

            // Get user agent service
            var userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();

            // Apply custom font family to all headings
            userAgent.UserStyleSheet = "h1, h2, h3, h4, h5, h6 { font-family: 'Comic Sans MS', cursive; }";

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Heading 1</h1><h2>Heading 2</h2><p>Paragraph text.</p></body></html>";

            // Load HTML document with base URI and configuration
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration);

            // Set XPS save options
            var options = new Aspose.Html.Saving.XpsSaveOptions();

            // Output file path
            string outputPath = "output.xps";

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion to XPS completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}