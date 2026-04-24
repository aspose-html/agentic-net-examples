// Convert HTML to JPEG using a temporary directory for output and clean up the directory afterwards.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        try
        {
            // Create temporary directory for output
            Directory.CreateDirectory(tempDir);

            // Path to the source HTML file (ensure this file exists)
            string inputHtml = "sample.html";

            // Path for the JPEG output inside the temporary directory
            string outputPath = Path.Combine(tempDir, "output.jpg");

            // Load HTML document and convert to JPEG
            using (HTMLDocument document = new HTMLDocument(inputHtml))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine($"JPEG image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // Clean up the temporary directory and its contents
            try
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
            catch
            {
                // Suppress any cleanup exceptions
            }
        }
    }
}