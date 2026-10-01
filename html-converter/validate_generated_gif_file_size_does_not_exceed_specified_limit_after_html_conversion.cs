// Validate that generated GIF file size does not exceed a specified limit after HTML conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set image save options for GIF format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Validate file size against limit (e.g., 100 KB)
            long maxSizeBytes = 100 * 1024; // 100 KB
            long actualSize = new FileInfo(outputPath).Length;

            if (actualSize > maxSizeBytes)
            {
                Console.WriteLine($"Generated GIF size ({actualSize} bytes) exceeds the limit of {maxSizeBytes} bytes.");
            }
            else
            {
                Console.WriteLine($"Generated GIF size ({actualSize} bytes) is within the limit of {maxSizeBytes} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}