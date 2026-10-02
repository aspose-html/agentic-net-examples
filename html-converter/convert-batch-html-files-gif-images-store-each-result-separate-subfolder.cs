// Convert a batch of HTML files to GIF images and store each result in a separate subfolder.

using System;
using System.IO;
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
            string inputFolder = "InputHtml";
            string outputFolder = "OutputGifs";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string subFolder = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath));
                Directory.CreateDirectory(subFolder);

                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    string outputPath = Path.Combine(subFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".gif");
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