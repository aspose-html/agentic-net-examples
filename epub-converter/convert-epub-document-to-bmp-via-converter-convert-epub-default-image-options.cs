// Convert an EPUB document to BMP format by calling Converter.ConvertEPUB with default image options.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                using (FileStream fs = File.Create(inputPath))
                {
                    // Placeholder EPUB file
                }
            }

            System.IO.Stream stream = File.OpenRead(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            stream.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}