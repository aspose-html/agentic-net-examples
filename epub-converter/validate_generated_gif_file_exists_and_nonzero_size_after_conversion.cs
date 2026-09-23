// Validate that the generated GIF file exists and has a non-zero file size after conversion.

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
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set GIF conversion options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Validate the generated GIF file
            if (File.Exists(outputPath))
            {
                long fileSize = new FileInfo(outputPath).Length;
                if (fileSize > 0)
                {
                    Console.WriteLine("GIF conversion succeeded. File size: " + fileSize + " bytes.");
                }
                else
                {
                    Console.WriteLine("GIF conversion failed: generated file is empty.");
                }
            }
            else
            {
                Console.WriteLine("GIF conversion failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}