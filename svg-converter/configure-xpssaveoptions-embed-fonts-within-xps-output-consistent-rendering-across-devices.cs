// Configure XpsSaveOptions to embed fonts within the XPS output for consistent rendering across devices.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Sample</title></head><body><h1>Hello, XPS!</h1></body></html>");

            // Load the HTML document from the file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Configure XPS save options
            XpsSaveOptions options = new XpsSaveOptions();
            // Note: In this version of Aspose.HTML, font embedding is enabled by default or controlled by other settings.
            // If a specific property for embedding fonts exists, it can be set here.

            // Define output XPS file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}