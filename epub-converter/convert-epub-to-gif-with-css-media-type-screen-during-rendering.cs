// Convert EPUB to GIF using ImageSaveOptions.CssMediaType='screen' to reflect screen‑based CSS rules during rendering.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.epub";
                string outputPath = "output.gif";

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                System.Console.WriteLine("EPUB converted to GIF successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}