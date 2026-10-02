// Batch convert HTML files in subfolders to PNG while preserving original folder hierarchy.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories))
            {
                string relativePath = Path.GetRelativePath(inputFolder, htmlPath);
                string outputDir = Path.Combine(outputFolder, Path.GetDirectoryName(relativePath) ?? string.Empty);
                Directory.CreateDirectory(outputDir);

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(htmlPath) + ".png");

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}