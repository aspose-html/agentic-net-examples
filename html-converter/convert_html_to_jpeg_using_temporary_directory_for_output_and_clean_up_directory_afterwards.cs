// Convert HTML to JPEG using a temporary directory for output and clean up the directory afterwards.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputDir = null;
        string outputDir = null;

        try
        {
            // Create temporary input and output directories
            inputDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlInput_" + Guid.NewGuid().ToString("N"));
            outputDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlOutput_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample HTML file
            string sampleHtmlPath = Path.Combine(inputDir, "sample.html");
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(sampleHtmlPath, htmlContent);

            // Convert each HTML file to JPEG
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed. Output files were saved to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Clean up temporary directories
            if (inputDir != null && Directory.Exists(inputDir))
            {
                Directory.Delete(inputDir, true);
            }
            if (outputDir != null && Directory.Exists(outputDir))
            {
                Directory.Delete(outputDir, true);
            }
        }
    }
}