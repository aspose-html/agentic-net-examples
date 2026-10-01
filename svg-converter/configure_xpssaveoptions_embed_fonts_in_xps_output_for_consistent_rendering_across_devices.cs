// Configure XpsSaveOptions to embed fonts within the XPS output for consistent rendering across devices.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello Aspose HTML</h1></body></html>";

            // Load HTML document from the string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Set XPS save options (default options)
            var options = new Aspose.Html.Saving.XpsSaveOptions();

            // Define output file path
            string outputPath = "output.xps";

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Output file: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}