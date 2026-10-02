// Batch transform EPUB documents into GIF animations by iterating over source files and calling Converter.ConvertEPUB.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "InputEpubs";
            string outputDirectory = "OutputGifs";

            System.IO.Directory.CreateDirectory(inputDirectory);
            System.IO.Directory.CreateDirectory(outputDirectory);

            string[] epubFiles = System.IO.Directory.GetFiles(inputDirectory, "*.epub");

            foreach (string epubPath in epubFiles)
            {
                string outputPath = System.IO.Path.Combine(
                    outputDirectory,
                    System.IO.Path.GetFileNameWithoutExtension(epubPath) + ".gif");

                using (System.IO.FileStream epubStream = System.IO.File.OpenRead(epubPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Gif);

                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                }

                Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}