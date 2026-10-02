// Convert HTML to TIFF by parsing command line arguments for input and output paths in a console app.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath;
            string outputPath;

            if (args.Length >= 2)
            {
                inputPath = args[0];
                outputPath = args[1];
            }
            else
            {
                // Create a minimal HTML file for demonstration
                string tempDir = Path.GetTempPath();
                inputPath = Path.Combine(tempDir, "sample.html");
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");
            }

            // Load the HTML document from the file path
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set up image save options for TIFF format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

            // Convert HTML to TIFF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Input: " + inputPath);
            Console.WriteLine("Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}