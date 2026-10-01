// Batch render a series of HTML newsletters to PNG images with consistent background color.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file path and create a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Define output image path
            string outputPath = "output.png";

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.Beige;

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}