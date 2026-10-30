// Create a JPEG image from MHTML by applying compression quality through ImageSaveOptions configuration.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.jpg";

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}