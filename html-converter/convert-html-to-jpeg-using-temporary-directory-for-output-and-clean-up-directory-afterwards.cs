// Convert HTML to JPEG using a temporary directory for output and clean up the directory afterwards.

using System;
using System.IO;
using System.Text;
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
            // Prepare temporary input and output directories
            string inputFolder = Path.Combine(Path.GetTempPath(), "AsposeHtmlInput_" + Guid.NewGuid().ToString("N"));
            string outputFolder = Path.Combine(Path.GetTempPath(), "AsposeHtmlOutput_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(sampleHtmlPath, htmlContent, Encoding.UTF8);

            // Convert each HTML file to JPEG
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine("Converted: " + outputPath);
                }
            }

            // Clean up temporary directories
            Directory.Delete(inputFolder, true);
            Directory.Delete(outputFolder, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}