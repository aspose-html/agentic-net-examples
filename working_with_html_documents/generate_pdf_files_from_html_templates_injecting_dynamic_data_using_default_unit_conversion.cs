// Generate PDF files from HTML templates, injecting dynamic data and using default unit conversion.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML template with a placeholder for dynamic data
                string template = "<html><body><h1>Hello, {{Name}}!</h1></body></html>";
                // Replace placeholder with actual value
                string htmlContent = template.Replace("{{Name}}", "John Doe");
                // Base URI for resolving relative resources (if any)
                string baseUri = "file:///";
                // Path where the resulting PDF will be saved
                string outputPath = "result.pdf";

                // Create an HTMLDocument from the HTML string and base URI
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                // Initialize PDF save options with default settings
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                // Convert the HTML document to PDF and save it to the specified path
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("PDF generated successfully at " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}