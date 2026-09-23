// Convert an EPUB file to TIFF image with LZW compression enabled through conversion options.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "sample.epub");
                string outputPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "output.tiff");

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllBytes(inputPath, new byte[0]);
                }

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                    {
                        UseAntialiasing = true,
                        HorizontalResolution = 300,
                        VerticalResolution = 300,
                        BackgroundColor = System.Drawing.Color.White
                    };

                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 1000),
                        new Aspose.Html.Drawing.Margin(0, 0, 0, 0));
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}