// Batch render a series of HTML newsletters to PNG images with consistent background color.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");

            // Ensure directories exist
            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Sample HTML newsletters
            var newsletters = new List<(string FileName, string HTMLContent)>
            {
                ("newsletter1.html", "<html><body><h1>Newsletter 1</h1><p>Welcome to our first newsletter.</p></body></html>"),
                ("newsletter2.html", "<html><body><h1>Newsletter 2</h1><p>Latest updates and news.</p></body></html>"),
                ("newsletter3.html", "<html><body><h1>Newsletter 3</h1><p>Special offers inside.</p></body></html>")
            };

            // Write sample HTML files
            foreach (var (fileName, htmlContent) in newsletters)
            {
                string filePath = Path.Combine(inputDir, fileName);
                File.WriteAllText(filePath, htmlContent);
            }

            // Configure image save options with consistent background color
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Beige;
            options.UseAntialiasing = false;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Batch render each newsletter to PNG
            foreach (var (fileName, _) in newsletters)
            {
                string htmlPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".png");

                HTMLDocument document = new HTMLDocument(htmlPath);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Batch rendering completed successfully.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}