// Batch convert a directory of HTML files to high‑resolution JPGs by iterating over ConvertHTML with ImageRenderingOptions.

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
            // Folder containing source HTML files
            string inputFolder = "InputHtml";
            // Folder where JPEG images will be saved
            string outputFolder = "OutputJpg";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure image save options for high‑resolution JPEG
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.VerticalResolution = 300;   // DPI
                    options.HorizontalResolution = 300; // DPI

                    // Determine output file path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    // Convert the HTML document to JPEG
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}