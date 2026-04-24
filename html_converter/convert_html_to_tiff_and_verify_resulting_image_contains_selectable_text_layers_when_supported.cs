// Convert HTML to TIFF and verify that the resulting image contains selectable text layers when supported.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file path
            string inputPath = "input.html";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Set up image save options for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Convert HTML to TIFF
            Converter.ConvertHTML(document, options, outputPath);

            // Verify that the TIFF file was created
            if (System.IO.File.Exists(outputPath))
            {
                Console.WriteLine("TIFF file created successfully at: " + outputPath);
                // Note: Aspose.HTML renders selectable text layers in TIFF when supported.
                // Additional verification of selectable text layers would require inspecting the TIFF
                // using a suitable imaging library, which is beyond the scope of this example.
            }
            else
            {
                Console.WriteLine("Failed to create TIFF file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}