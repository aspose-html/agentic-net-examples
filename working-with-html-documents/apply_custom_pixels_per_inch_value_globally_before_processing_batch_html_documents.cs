// Apply a custom PixelsPerInch value globally before processing a batch of HTML documents.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare output directory
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                Directory.CreateDirectory(outputDir);

                // Prepare input directory and sample files
                string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
                Directory.CreateDirectory(inputDir);

                string[] inputs = new string[]
                {
                    Path.Combine(inputDir, "sample1.html"),
                    Path.Combine(inputDir, "sample2.html")
                };

                if (!File.Exists(inputs[0]))
                {
                    File.WriteAllText(inputs[0], "<html><body><h1>Sample 1</h1></body></html>");
                }

                if (!File.Exists(inputs[1]))
                {
                    File.WriteAllText(inputs[1], "<html><body><h1>Sample 2</h1></body></html>");
                }

                // Process each input file
                for (int i = 0; i < inputs.Length; i++)
                {
                    string inputPath = inputs[i];

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, Directory.GetCurrentDirectory()))
                    {
                        // Create watermark element
                        Aspose.Html.Dom.Element div = document.CreateElement("div");
                        div.SetAttribute("style", "position:absolute; top:10px; left:10px; font-size:24px; color:red; opacity:0.5;");
                        div.TextContent = "Watermark";
                        document.Body.AppendChild(div);

                        // Configure image save options
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.HorizontalResolution = 96;
                        options.VerticalResolution = 96;

                        // Define output image path
                        string outputPath = Path.Combine(outputDir, $"output_{i + 1}.jpeg");

                        // Convert HTML to JPEG image
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}