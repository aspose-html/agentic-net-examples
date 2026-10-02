// Convert multiple EPUB files in a folder to GIFs using a loop and shared ImageSaveOptions.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputGifs";

            System.IO.Directory.CreateDirectory(inputDir);
            System.IO.Directory.CreateDirectory(outputDir);

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.UseAntialiasing = true;

            string[] epubFiles = System.IO.Directory.GetFiles(inputDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = System.IO.Path.Combine(outputDir, fileName + ".gif");

                using (System.IO.FileStream stream = System.IO.File.OpenRead(epubPath))
                {
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