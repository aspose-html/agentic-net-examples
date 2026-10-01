// Convert an HTML file to a GIF image using default conversion and store the output in a folder.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><body><h1>Hello, World!</h1></body></html>");
            }

            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputHtmlPath) + ".gif");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}