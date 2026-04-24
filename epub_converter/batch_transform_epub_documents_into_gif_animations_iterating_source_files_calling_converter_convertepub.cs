// Batch transform EPUB documents into GIF animations by iterating over source files and calling Converter.ConvertEPUB.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "input_epubs";
            string outputDirectory = "output_gifs";

            Directory.CreateDirectory(outputDirectory);

            foreach (string epubPath in Directory.GetFiles(inputDirectory, "*.epub"))
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExtension + ".gif");

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    Converter.ConvertEPUB(stream, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}