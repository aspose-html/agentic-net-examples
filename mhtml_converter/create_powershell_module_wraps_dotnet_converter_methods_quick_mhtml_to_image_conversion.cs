// Create a PowerShell module that wraps .NET Converter methods for quick MHTML to image conversions.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string format = "png"; // supported: png, jpeg, bmp, tiff
            string outputPath = ConvertMhtmlByFormat(inputPath, format);
            Console.WriteLine($"Conversion succeeded: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }

    static string ConvertMhtmlByFormat(string inputPath, string format)
    {
        ImageSaveOptions options;
        string extension;

        switch (format.ToLower())
        {
            case "png":
                options = new ImageSaveOptions(ImageFormat.Png);
                extension = ".png";
                break;
            case "jpeg":
            case "jpg":
                options = new ImageSaveOptions(ImageFormat.Jpeg);
                extension = ".jpg";
                break;
            case "bmp":
                options = new ImageSaveOptions(ImageFormat.Bmp);
                extension = ".bmp";
                break;
            case "tiff":
                options = new ImageSaveOptions(ImageFormat.Tiff);
                extension = ".tiff";
                break;
            default:
                throw new ArgumentException("Unsupported image format.");
        }

        string outputPath = System.IO.Path.ChangeExtension(inputPath, extension);
        Converter.ConvertMHTML(inputPath, options, outputPath);
        return outputPath;
    }
}