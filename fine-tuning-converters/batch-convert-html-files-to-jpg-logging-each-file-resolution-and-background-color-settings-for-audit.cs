// Batch convert HTML files to JPG, logging each file's resolution and background color settings for audit.

using System;
using System.IO;
using System.Drawing;
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
            // Prepare output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            // Input files
            string[] inputs = new string[] { "sample1.html", "sample2.html" };

            // Ensure sample input files exist
            for (int i = 0; i < inputs.Length; i++)
            {
                string path = inputs[i];
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.WriteAllText(path, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Sample " + (i + 1) + "</h1></body></html>");
                }
            }

            // Process each file
            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                using (var document = new Aspose.Html.HTMLDocument(inputPath, System.IO.Directory.GetCurrentDirectory()))
                {
                    // Configure image options
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.Beige;

                    string outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                    // Convert
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                    // Log audit information
                    System.Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'. Resolution: {options.HorizontalResolution}x{options.VerticalResolution} DPI, BackgroundColor: {options.BackgroundColor.Name}");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}