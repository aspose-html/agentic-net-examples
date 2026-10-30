// Validate that saved image files are not corrupted by checking file signatures after write operation.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            string svgPath = Path.Combine(inputFolder, "sample.svg");
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            File.WriteAllText(svgPath, svgContent);

            string highOutputPath = Path.Combine(outputFolder, "high.jpg");
            string lowOutputPath = Path.Combine(outputFolder, "low.jpg");

            Aspose.Html.Saving.ImageSaveOptions highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            highOptions.HorizontalResolution = 300;
            highOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            Aspose.Html.Saving.ImageSaveOptions lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            bool highValid = IsJpegValid(highOutputPath);
            bool lowValid = IsJpegValid(lowOutputPath);

            if (!highValid || !lowValid)
            {
                Console.WriteLine("One or both JPEG files are corrupted.");
                return;
            }

            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("High resolution image is larger than low resolution image.");
            }
            else
            {
                Console.WriteLine("Low resolution image is larger or equal to high resolution image.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static bool IsJpegValid(string path)
    {
        if (!File.Exists(path))
            return false;

        using (FileStream stream = File.OpenRead(path))
        {
            if (stream.Length < 4)
                return false;

            byte[] header = new byte[2];
            stream.Read(header, 0, 2);
            if (header[0] != 0xFF || header[1] != 0xD8)
                return false;

            stream.Seek(-2, SeekOrigin.End);
            byte[] footer = new byte[2];
            stream.Read(footer, 0, 2);
            if (footer[0] != 0xFF || footer[1] != 0xD9)
                return false;
        }

        return true;
    }
}