// Convert EPUB to TIFF with ImageSaveOptions.DpiX/DpiY configured at 600 for ultra‑high definition scans.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            // Create a minimal placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.HorizontalResolution = 600;
                options.VerticalResolution = 600;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to TIFF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}