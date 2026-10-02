// Create a helper that converts MHTML to multiple image formats and returns a dictionary of format‑to‑stream mappings.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal MHTML file (simple HTML content for demonstration)
            string mhtmlPath = Path.Combine(Path.GetTempPath(), "sample.mhtml");
            File.WriteAllText(mhtmlPath, "<html><body><h1>Hello World</h1></body></html>");

            // Desired image formats
            var formats = new List<string> { "jpeg", "png", "bmp", "gif", "tiff" };

            // Convert MHTML to images
            var images = ConvertToImages(mhtmlPath, formats);

            // Save the resulting images to temporary files
            foreach (var kvp in images)
            {
                string extension = GetExtension(kvp.Key);
                string outputPath = Path.Combine(Path.GetTempPath(), $"output_{kvp.Key}{extension}");
                using (FileStream fs = File.Create(outputPath))
                {
                    kvp.Value.CopyTo(fs);
                }
                Console.WriteLine($"Image saved: {outputPath}");
            }

            // Cleanup sample MHTML file
            File.Delete(mhtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, MemoryStream> ConvertToImages(string mhtmlPath, IEnumerable<string> formats)
    {
        var result = new Dictionary<string, MemoryStream>();

        foreach (var fmt in formats)
        {
            string lower = fmt.ToLowerInvariant();
            ImageFormat imageFormat;
            string extension;

            switch (lower)
            {
                case "jpeg":
                case "jpg":
                    imageFormat = ImageFormat.Jpeg;
                    extension = ".jpeg";
                    break;
                case "png":
                    imageFormat = ImageFormat.Png;
                    extension = ".png";
                    break;
                case "bmp":
                    imageFormat = ImageFormat.Bmp;
                    extension = ".bmp";
                    break;
                case "gif":
                    imageFormat = ImageFormat.Gif;
                    extension = ".gif";
                    break;
                case "tiff":
                case "tif":
                    imageFormat = ImageFormat.Tiff;
                    extension = ".tiff";
                    break;
                default:
                    // Unsupported format; skip
                    continue;
            }

            string tempOutputPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + extension);

            using (Stream inputStream = File.OpenRead(mhtmlPath))
            {
                var options = new ImageSaveOptions(imageFormat);
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempOutputPath);
            }

            byte[] bytes = File.ReadAllBytes(tempOutputPath);
            var memory = new MemoryStream(bytes);
            memory.Position = 0;
            result[fmt] = memory;

            // Delete temporary file
            File.Delete(tempOutputPath);
        }

        return result;
    }

    static string GetExtension(string fmt)
    {
        switch (fmt.ToLowerInvariant())
        {
            case "jpeg":
            case "jpg":
                return ".jpeg";
            case "png":
                return ".png";
            case "bmp":
                return ".bmp";
            case "gif":
                return ".gif";
            case "tiff":
            case "tif":
                return ".tiff";
            default:
                return ".img";
        }
    }
}