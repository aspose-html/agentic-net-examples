// Use HtmlRenderer.RenderToImage to produce PNG thumbnails of HTML pages at 200 px width.

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1><p>This is a sample page.</p></body></html>");

            // Define output PNG path
            string outputPath = "thumbnail.png";

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                // Configure rendering options for PNG with 200 px width
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToWidestContentWidth;
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(200, 0));

                // Create the image device
                Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

                // Render the document to the image device
                document.RenderTo(device);
            }

            System.Console.WriteLine("Thumbnail saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}