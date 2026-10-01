// Define custom background color in ImageSaveOptions before converting HTML to PNG to replace transparent areas.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

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
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image save options with PNG format and custom background color
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}