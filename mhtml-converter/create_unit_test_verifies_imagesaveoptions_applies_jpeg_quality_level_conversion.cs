// Create a unit test that verifies ImageSaveOptions correctly applies JPEG quality level during conversion.

using System;
using System.IO;
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
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Test Image</h1><p>This is a sample HTML for JPEG conversion.</p></body></html>";
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Define output JPEG path
            string jpegPath = Path.Combine(Path.GetTempPath(), "output.jpg");

            // Create ImageSaveOptions for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Convert HTML to JPEG using the options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, jpegPath);

            // Verify that the output file was created and has a non-zero size
            if (File.Exists(jpegPath))
            {
                long fileSize = new FileInfo(jpegPath).Length;
                if (fileSize > 0)
                {
                    Console.WriteLine("Conversion succeeded. JPEG file size: " + fileSize + " bytes.");
                }
                else
                {
                    Console.WriteLine("Conversion failed: JPEG file size is zero.");
                }
            }
            else
            {
                Console.WriteLine("Conversion failed: JPEG file was not created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}