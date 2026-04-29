// Batch convert all Markdown files in a folder to JPEG images applying a uniform quality level.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputImages";
            Directory.CreateDirectory(outputFolder);
            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(mdPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");
                HTMLDocument document = Converter.ConvertMarkdown(mdPath);
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertHTML(document, options, outputPath);
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}