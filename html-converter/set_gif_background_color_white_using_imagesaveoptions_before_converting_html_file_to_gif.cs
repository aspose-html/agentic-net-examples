// Set GIF background color to white using ImageSaveOptions before converting an HTML file to GIF.

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
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            HTMLDocument document = new HTMLDocument(htmlPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.BackgroundColor = Color.White;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}