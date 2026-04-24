// Apply CSS media type “print” in ImageSaveOptions before converting HTML to PNG for print‑ready output.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            // Load HTML content from a file
            string htmlContent = System.IO.File.ReadAllText("input.html");
            // Base URI for the HTML document (used for resolving relative resources)
            string baseUri = System.IO.Path.GetFullPath("input.html");
            // Destination path for the generated PNG image
            string outputPath = "output.png";

            // Create image save options for PNG output
            ImageSaveOptions options = new ImageSaveOptions();
            // Apply CSS media type "print" to ensure print‑ready rendering
            options.Css.MediaType = MediaType.Print;

            // Convert the HTML content to a PNG image using the specified options
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}