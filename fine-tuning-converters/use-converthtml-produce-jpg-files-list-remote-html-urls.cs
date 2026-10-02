// Use ConvertHTML with ImageRenderingOptions to produce JPG files from a list of remote HTML URLs.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // List of remote HTML URLs to convert
            string[] urls = new string[]
            {
                "https://example.com",
                "https://www.wikipedia.org"
            };

            // Output directory
            string outputFolder = "Output";
            Directory.CreateDirectory(outputFolder);

            for (int i = 0; i < urls.Length; i++)
            {
                // Create Aspose.Html.Url instance
                Aspose.Html.Url sourceUrl = new Aspose.Html.Url(urls[i]);

                // Load the HTML document from the URL
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);

                // Configure image save options for JPEG format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Determine output file path
                string outputPath = Path.Combine(outputFolder, $"page{i + 1}.jpg");

                // Convert HTML to JPEG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}