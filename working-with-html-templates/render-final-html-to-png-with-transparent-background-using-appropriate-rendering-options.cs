// Render the final HTML to PNG with transparent background using appropriate rendering options.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><h1 style='color:red;'>Hello, Aspose!</h1></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);

            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));
            options.BackgroundColor = System.Drawing.Color.Transparent;

            string outputPath = "output.png";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            document.RenderTo(device);

            Console.WriteLine("PNG image saved to " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}