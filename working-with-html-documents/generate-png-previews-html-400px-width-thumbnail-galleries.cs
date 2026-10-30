// Generate PNG previews of HTML pages at 400 px width for thumbnail galleries.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Sample</h1><p>This is a thumbnail preview.</p></body></html>";

            // Load HTML from string (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set rendering options with a fixed width of 400 pixels (height set to 300 as placeholder)
            Aspose.Html.Rendering.Image.ImageRenderingOptions renderOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(400, 300),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Create image device to render PNG file
            string outputPath = "thumbnail.png";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(renderOptions, outputPath);

            // Render the document to PNG
            document.RenderTo(device);

            Console.WriteLine($"Thumbnail image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}