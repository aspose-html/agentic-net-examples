// Batch render a series of HTML newsletters to PNG images with consistent background color.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML files and corresponding output PNG files
            string[] htmlFiles = new string[]
            {
                "newsletter1.html",
                "newsletter2.html",
                "newsletter3.html"
            };

            string[] pngOutputs = new string[]
            {
                "newsletter1.png",
                "newsletter2.png",
                "newsletter3.png"
            };

            // Ensure sample HTML files exist
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                if (!File.Exists(htmlFiles[i]))
                {
                    string sampleHtml = $"<html><head><title>Newsletter {i + 1}</title></head><body><h1>Newsletter {i + 1}</h1><p>This is a sample newsletter content.</p></body></html>";
                    File.WriteAllText(htmlFiles[i], sampleHtml);
                }
            }

            // Batch convert each HTML newsletter to PNG with consistent background color
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                string htmlPath = htmlFiles[i];
                string pngPath = pngOutputs[i];

                // Load HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Configure image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.BackgroundColor = System.Drawing.Color.Beige;

                // Convert HTML to PNG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pngPath);

                System.Console.WriteLine($"Converted '{htmlPath}' to '{pngPath}'.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}