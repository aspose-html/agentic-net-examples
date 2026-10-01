// Batch process a directory of HTML files to add alt text and save each modified file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                string sampleHtmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Test Image</h1>
    <img src='https://via.placeholder.com/150' />
</body>
</html>";
                File.WriteAllText(sampleHtmlPath, sampleHtmlContent);
            }

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load HTML document
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    // Get all <img> elements
                    Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

                    // Ensure each image has an alt attribute
                    foreach (Aspose.Html.Dom.Element node in images)
                    {
                        Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                        if (img != null)
                        {
                            string alt = img.GetAttribute("alt");
                            if (string.IsNullOrWhiteSpace(alt))
                            {
                                string autoAlt = "Image";
                                img.SetAttribute("alt", autoAlt);
                            }
                        }
                    }

                    // Save the possibly modified document back to the same file
                    document.Save(htmlPath);

                    // Prepare image conversion options
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                    // Define output image path
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    // Convert HTML to JPEG image
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}