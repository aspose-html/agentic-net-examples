// Create an ImageDevice for JPG output with a black background by setting RenderingOptions.BackgroundColor.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML file
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options with black background
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.BackgroundColor = System.Drawing.Color.Black;
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.jpg");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}