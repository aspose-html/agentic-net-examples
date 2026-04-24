// Read HTML content from a string, set base URI, and render directly to a PNG image using ImageDevice.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // HTML markup to be rendered
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Base URI for resolving relative resources (can be the current directory)
            string baseUri = AppDomain.CurrentDomain.BaseDirectory;

            // Load HTML content into a document with the specified base URI
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Configure image rendering options (default settings)
            ImageRenderingOptions imgOptions = new ImageRenderingOptions();

            // Create an image device that will write the PNG output to the given file path
            string outputPath = "output.png";
            ImageDevice imgDevice = new ImageDevice(imgOptions, outputPath);

            // Render the HTML document to the PNG image
            document.RenderTo(imgDevice);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}