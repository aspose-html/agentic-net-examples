// Implement a method that returns a dictionary mapping each supported output format to its conversion success flag.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace AsposeHtmlConversionDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                string mhtmlPath = "sample.mhtml";
                var formats = new List<string> { "jpeg", "png", "bmp", "gif", "tiff" };
                var results = ConvertMhtmlToImages(mhtmlPath, formats);
                foreach (var kvp in results)
                {
                    Console.WriteLine($"{kvp.Key}: {(kvp.Value ? "Success" : "Failed")}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        static Dictionary<string, bool> ConvertMhtmlToImages(string mhtmlPath, IEnumerable<string> formats)
        {
            var result = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
            foreach (var formatName in formats)
            {
                bool success = false;
                try
                {
                    ImageFormat imageFormat = MapToImageFormat(formatName);
                    var options = new ImageSaveOptions(imageFormat);
                    string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}{GetExtension(imageFormat)}");
                    Converter.ConvertMHTML(mhtmlPath, options, tempFile);
                    if (File.Exists(tempFile))
                    {
                        success = true;
                        File.Delete(tempFile);
                    }
                }
                catch
                {
                    success = false;
                }
                result[formatName] = success;
            }
            return result;
        }

        static ImageFormat MapToImageFormat(string format)
        {
            switch (format.Trim().ToLowerInvariant())
            {
                case "jpeg":
                case "jpg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                case "bmp":
                    return ImageFormat.Bmp;
                case "gif":
                    return ImageFormat.Gif;
                case "tiff":
                case "tif":
                    return ImageFormat.Tiff;
                default:
                    throw new ArgumentException($"Unsupported image format: {format}");
            }
        }

        static string GetExtension(ImageFormat format)
        {
            if (format == ImageFormat.Jpeg) return ".jpg";
            if (format == ImageFormat.Png) return ".png";
            if (format == ImageFormat.Bmp) return ".bmp";
            if (format == ImageFormat.Gif) return ".gif";
            if (format == ImageFormat.Tiff) return ".tiff";
            return ".img";
        }
    }
}