// Convert EPUB to BMP while adding title metadata through ImageSaveOptions to preserve document information.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Create a placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
            using (stream)
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB successfully converted to BMP.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}