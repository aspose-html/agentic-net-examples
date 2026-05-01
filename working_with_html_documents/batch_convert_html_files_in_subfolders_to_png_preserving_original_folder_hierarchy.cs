// Batch convert HTML files in subfolders to PNG while preserving original folder hierarchy.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputPng";
            Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories))
            {
                string relativePath = Path.GetRelativePath(inputFolder, htmlPath);
                string relativeDir = Path.GetDirectoryName(relativePath);
                string outputDir = Path.Combine(outputFolder, relativeDir ?? string.Empty);
                Directory.CreateDirectory(outputDir);
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(htmlPath) + ".png");
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}