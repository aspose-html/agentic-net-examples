// Convert an EPUB file to JPG images using default settings, saving each page as a separate file.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputDir = "output";
                System.IO.Directory.CreateDirectory(outputDir);
                string outputPath = System.IO.Path.Combine(outputDir, "page");

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                System.Console.WriteLine("EPUB conversion to JPEG completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}