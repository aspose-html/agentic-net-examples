// Convert HTML to PNG while applying custom page settings such as resolution and margins using ImageSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure image save options with PNG format, resolution, and margins
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(50, 50, 50, 50));

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to PNG using the configured options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}