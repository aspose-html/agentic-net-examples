// Create a script that reads HTML files from a network share and converts each to GIF using defaults.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"\\server\share\html";
            string outputFolder = @"C:\Output\Gif";

            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".gif");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}