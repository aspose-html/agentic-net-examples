// Batch convert all EPUB files in a directory to JPEG images using a loop over Converter.ConvertEPUB.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputEpubs";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            foreach (string epubPath in Directory.GetFiles(inputFolder, "*.epub"))
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(epubPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            }

            Console.WriteLine("EPUB to JPEG conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}