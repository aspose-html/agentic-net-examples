// Render the final HTML to PNG with transparent background using appropriate rendering options.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body style='margin:0;padding:0;'><svg width='200' height='200'><circle cx='100' cy='100' r='80' fill='red' /></svg></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Rendering.Image.ImageRenderingOptions renderOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(400, 400));
            renderOptions.BackgroundColor = System.Drawing.Color.Transparent;

            string outputPath = "output.png";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(renderOptions, outputPath);

            document.RenderTo(device);

            Console.WriteLine("HTML rendered to PNG with transparent background: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}