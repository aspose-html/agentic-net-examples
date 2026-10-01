// Create a BMP thumbnail representing page one of an EPUB using ImageSaveOptions to select the initial page.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "thumbnail.bmp";

                System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath);
                using (inputStream)
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
                }

                System.Console.WriteLine("Thumbnail saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}