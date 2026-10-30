// Set JPEG device options to use quality 85 when rendering HTML from ZIP to JPG.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = "extracted";
            string htmlFileName = "index.html";
            string outputPath = "output.jpg";

            // Ensure the ZIP file exists with a simple HTML file inside
            if (!File.Exists(zipPath))
            {
                // Create a temporary directory for the HTML file
                string tempDir = "tempHtml";
                Directory.CreateDirectory(tempDir);
                string htmlFilePath = Path.Combine(tempDir, htmlFileName);
                File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><body><h1>Hello from ZIP!</h1></body></html>");

                // Create the ZIP archive
                ZipFile.CreateFromDirectory(tempDir, zipPath);
                Directory.Delete(tempDir, true);
            }

            // Extract the ZIP archive
            if (Directory.Exists(extractDir))
                Directory.Delete(extractDir, true);
            ZipFile.ExtractToDirectory(zipPath, extractDir);

            // Load the HTML document from the extracted file
            string htmlPath = Path.Combine(extractDir, htmlFileName);
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options for JPEG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}