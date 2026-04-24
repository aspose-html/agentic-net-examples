// Convert HTML to TIFF using a temporary file for intermediate storage and delete the file after conversion.

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
            // Create a temporary HTML file
            string tempHtmlPath = Path.ChangeExtension(Path.GetTempFileName(), ".html");
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(tempHtmlPath, htmlContent);

            // Define output TIFF path
            string outputTiffPath = "output.tiff";

            // Load the HTML document from the temporary file
            HTMLDocument document = new HTMLDocument(tempHtmlPath);

            // Set up image save options for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Convert HTML to TIFF
            Converter.ConvertHTML(document, options, outputTiffPath);

            // Delete the temporary HTML file
            File.Delete(tempHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}