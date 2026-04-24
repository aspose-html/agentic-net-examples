// Perform a one‑line static conversion of HTML string to PNG by calling Converter.ConvertHTML with ImageSaveOptions.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            // Base URI for the HTML content (required for relative resources)
            string baseUri = "file:///";
            // Configure image saving options (defaults are sufficient for PNG)
            ImageSaveOptions options = new ImageSaveOptions();
            // Output file path for the generated PNG
            string outputPath = "output.png";

            // Perform the conversion in a single line
            Converter.ConvertHTML(html, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}