// Convert EPUB to BMP using ImageSaveOptions to specify 200 DPI, producing sharper bitmap images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.HorizontalResolution = 200;
                options.VerticalResolution = 200;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB converted to BMP successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}