// Replace all em dashes with double hyphens to ensure compatibility with plain‑text viewers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create an HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Set up save options for PDF (Doc format)
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}