// Batch render a series of HTML newsletters to PNG images with consistent background color.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing HTML newsletters
            string inputFolder = @"C:\Newsletters\Html";
            // Folder where PNG images will be saved
            string outputFolder = @"C:\Newsletters\Images";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files in the input folder
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            foreach (string htmlPath in htmlFiles)
            {
                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Configure image save options for PNG with a consistent background color
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.UseAntialiasing = false;
                options.BackgroundColor = System.Drawing.Color.Beige;

                // Determine output PNG path (same file name, .png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(htmlPath);
                string pngPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Convert HTML to PNG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pngPath);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}