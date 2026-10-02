// Set JPEG device options to use quality 85 when rendering HTML from ZIP to JPG.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input ZIP and output JPG paths
            string zipPath = "input.zip";
            string outputPath = "output.jpg";

            // Create a temporary folder for extraction
            string extractFolder = Path.Combine(Path.GetTempPath(), "HTMLFromZip");
            if (Directory.Exists(extractFolder))
            {
                Directory.Delete(extractFolder, true);
            }
            Directory.CreateDirectory(extractFolder);

            // Extract ZIP contents
            ZipFile.ExtractToDirectory(zipPath, extractFolder);

            // Assume the main HTML file is named "index.html"
            string htmlPath = Path.Combine(extractFolder, "index.html");

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}