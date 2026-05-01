// Batch convert a directory of HTML files to JPG images with uniform dimensions using ImageDevice.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputJpg";
            Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
                    options.PageSetup.AnyPage = new Page(new Size(800, 600));
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    ImageDevice device = new ImageDevice(options, outputPath);
                    document.RenderTo(device);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}