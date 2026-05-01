// Batch render HTML tutorials to PNG images, adding a footer with page numbers after rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\HtmlTutorials";
            string outputFolder = @"C:\RenderedImages";
            Directory.CreateDirectory(outputFolder);
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlFile in htmlFiles)
            {
                try
                {
                    string documentPath = htmlFile;
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);
                    Aspose.Html.Rendering.Image.ImageRenderingOptions opt = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlFile) + ".png");
                    Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(opt, outputPath);
                    document.RenderTo(device);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {htmlFile}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}