// Configure ImageSaveOptions to enable progressive rendering for JPEG output when converting large MHTML files.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.jpg";

            Stream stream = File.OpenRead(inputPath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}