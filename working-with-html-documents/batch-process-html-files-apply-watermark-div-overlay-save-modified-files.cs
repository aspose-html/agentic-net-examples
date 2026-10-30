// Batch process HTML files, apply a watermark div overlay, and save each modified file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Define input HTML files
            string[] inputs = new string[] { "input1.html", "input2.html" };

            // Create minimal sample input files if they do not exist
            for (int i = 0; i < inputs.Length; i++)
            {
                if (!File.Exists(inputs[i]))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Sample Content " + (i + 1) + "</h1></body></html>";
                    File.WriteAllText(inputs[i], sampleHtml);
                }
            }

            // Process each HTML file
            for (int i = 0; i < inputs.Length; i++)
            {
                using (HTMLDocument document = new HTMLDocument(inputs[i]))
                {
                    // Create watermark element
                    Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:fixed; top:10px; left:10px; color:red; font-size:36px; pointer-events:none; opacity:0.5;");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);

                    // Prepare image save options (JPEG)
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    // Define output image path
                    string outputPath = Path.Combine(outputDir, string.Format("output_{0}.jpg", i));

                    // Convert HTML to JPEG image
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Processing completed. Images saved to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}