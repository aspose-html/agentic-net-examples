// Load an EPUB file from disk and convert it to a GIF using default settings.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "output.gif";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllBytes(inputPath, new byte[0]);
                }

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}