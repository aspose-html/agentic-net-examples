// Configure ImageSaveOptions to set pixel format to 24‑bit when converting MHTML to BMP for compatibility.

using System;

class Program
{
    static void Main(string[] args)
    {
        System.IO.Stream stream = null;
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.bmp";

            if (!System.IO.File.Exists(inputPath))
            {
                string minimalMhtml = "From: test@example.com\r\nSubject: Sample\r\n\r\n<html><body><h1>Sample</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, minimalMhtml);
            }

            stream = System.IO.File.OpenRead(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (stream != null)
            {
                stream.Dispose();
            }
        }
    }
}