// Convert HTML to PNG with custom DPI of 150 for printing purposes by configuring ImageSaveOptions accordingly.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body><h1>Hello, Aspose!</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, sampleHtml);
            }

            // Configure image save options with PNG format and custom DPI
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}