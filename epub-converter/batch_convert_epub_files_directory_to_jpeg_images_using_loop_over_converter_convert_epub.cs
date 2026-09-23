// Batch convert all EPUB files in a directory to JPEG images using a loop over Converter.ConvertEPUB.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputEpubs";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(outputFolder);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            foreach (string epubPath in Directory.GetFiles(inputFolder, "*.epub"))
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(epubPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}