// Convert an HTML string to a DOCX file while applying DocSaveOptions to embed custom CSS styles.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML markup to be converted
            string htmlContent = "<html><head><style>p { color: red; }</style></head><body><p>Hello World</p></body></html>";
            // Base URI for resolving relative resources (if any)
            string baseUri = "file:///";

            // Create DocSaveOptions to configure DOCX output (custom CSS can be embedded via the HTML itself)
            DocSaveOptions options = new DocSaveOptions();

            // Output DOCX file path
            string outputPath = "output.docx";

            // Perform conversion from HTML string to DOCX
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("HTML successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}