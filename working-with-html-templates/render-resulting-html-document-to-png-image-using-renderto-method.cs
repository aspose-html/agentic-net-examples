// Render the resulting HTML document to a PNG image using the RenderTo method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define inline HTML content
            string htmlCode = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Base URI required for inline content
            string baseUri = "about:blank";

            // Load the HTML document from the string
            Aspose.Html.HTMLDocument htmlDocument = new Aspose.Html.HTMLDocument(htmlCode, baseUri);

            // Output PNG file path
            string outputPath = "output.png";

            // Configure image rendering options (default settings)
            Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();

            // Create an image device that writes to the specified file
            Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);

            // Render the HTML document to the image device (produces PNG)
            htmlDocument.RenderTo(imgDevice);

            Console.WriteLine("HTML rendered to PNG successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}