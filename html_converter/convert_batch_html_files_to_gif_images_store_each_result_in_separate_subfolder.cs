// Convert a batch of HTML files to GIF images and store each result in a separate subfolder.

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
            // Define input folder containing HTML files
            string inputFolder = "InputHtml";
            // Define base output folder where subfolders will be created
            string outputFolder = "OutputGifs";

            // Ensure the base output folder exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure image save options for GIF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                    // Create a subfolder named after the HTML file (without extension)
                    string subFolder = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath));
                    Directory.CreateDirectory(subFolder);

                    // Define the output GIF file path inside the subfolder
                    string outputPath = Path.Combine(subFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".gif");

                    // Convert the HTML document to GIF and save it
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}