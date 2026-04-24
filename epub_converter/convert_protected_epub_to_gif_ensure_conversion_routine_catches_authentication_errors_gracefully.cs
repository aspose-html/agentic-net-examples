// Convert a protected EPUB to GIF and ensure the conversion routine catches authentication errors gracefully.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the protected EPUB file
            string inputPath = "protected.epub";

            // Desired output GIF file path
            string outputPath = "output.gif";

            // Open the EPUB file as a readable stream
            FileStream stream = File.OpenRead(inputPath);

            // Configure image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Perform the conversion
            Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (UnauthorizedAccessException ex)
        {
            // Handle authentication/authorization errors gracefully
            Console.WriteLine("Authentication error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other conversion errors
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}