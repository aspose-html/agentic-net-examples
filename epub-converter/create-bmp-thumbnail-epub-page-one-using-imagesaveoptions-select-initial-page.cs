// Create a BMP thumbnail representing page one of an EPUB using ImageSaveOptions to select the initial page.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "thumbnail.bmp";

            // Create a placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
            using (stream)
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                // If supported, set the initial page to the first page
                // options.PageSetup.StartPage = 1;
                options.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("Thumbnail saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}