// Batch transform EPUB documents into GIF animations by iterating over source files and calling Converter.ConvertEPUB.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDir = "InputEpubs";
                string outputDir = "OutputGifs";

                System.IO.Directory.CreateDirectory(outputDir);

                string[] epubFiles = System.IO.Directory.GetFiles(inputDir, "*.epub");

                foreach (string epubPath in epubFiles)
                {
                    using (System.IO.FileStream epubStream = System.IO.File.OpenRead(epubPath))
                    {
                        string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(epubPath);
                        string outputPath = System.IO.Path.Combine(outputDir, fileNameWithoutExt + ".gif");

                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                        options.UseAntialiasing = true;

                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}