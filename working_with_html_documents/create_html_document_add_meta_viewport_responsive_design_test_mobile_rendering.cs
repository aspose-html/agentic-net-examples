// Create an HTML document, add a meta viewport for responsive design, and test on mobile rendering.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a meta viewport element
            Element meta = document.CreateElement("meta");
            meta.SetAttribute("name", "viewport");
            meta.SetAttribute("content", "width=device-width, initial-scale=1.0");

            // Append the meta element to the head section
            Element head = (Element)document.GetElementsByTagName("head")[0];
            head.AppendChild(meta);

            // Render the document to an image to test mobile rendering
            string outputPath = "output.png";
            ImageRenderingOptions options = new ImageRenderingOptions();
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}