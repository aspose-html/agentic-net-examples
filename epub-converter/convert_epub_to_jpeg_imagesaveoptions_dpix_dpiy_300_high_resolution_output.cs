// Convert EPUB to JPEG with ImageSaveOptions.DpiX and DpiY set to 300 for high‑resolution output.

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputPath = System.IO.Path.Combine(dataDir, "sample.epub");
            string outputPath = System.IO.Path.Combine(dataDir, "output.jpg");

            System.IO.Directory.CreateDirectory(dataDir);

            if (!System.IO.File.Exists(inputPath))
            {
                using (var fs = System.IO.File.Create(inputPath))
                {
                    // Minimal placeholder EPUB file (empty)
                }
            }

            using (var stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}