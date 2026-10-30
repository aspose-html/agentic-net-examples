// Implement a method that returns a dictionary mapping each supported output format to its conversion success flag.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file (empty content for demonstration)
            string mhtmlPath = Path.Combine(Path.GetTempPath(), "sample.mhtml");
            File.WriteAllText(mhtmlPath, string.Empty);

            // Define the formats we want to attempt conversion for
            var formats = new List<string> { "JPEG", "PNG", "GIF", "BMP", "TIFF" };

            // Perform conversions and obtain success flags
            var conversionResults = ConvertMhtmlToImages(mhtmlPath, formats);

            // Output the results
            foreach (var kvp in conversionResults)
            {
                Console.WriteLine($"{kvp.Key}: {(kvp.Value ? "Success" : "Failed")}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Dictionary<string, bool> ConvertMhtmlToImages(string mhtmlPath, IEnumerable<string> formats)
    {
        var result = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

        foreach (var format in formats)
        {
            bool success = false;
            try
            {
                // Map format string to Aspose.Html.Rendering.Image.ImageFormat
                ImageFormat imageFormat = GetImageFormat(format);

                // Create fresh input stream for each conversion
                using (FileStream inputStream = File.OpenRead(mhtmlPath))
                {
                    // Configure image save options
                    var options = new ImageSaveOptions(imageFormat);

                    // Build temporary output file path with correct extension
                    string extension = GetExtensionForImageFormat(imageFormat);
                    string tempOutputPath = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}{extension}");

                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempOutputPath);

                    // Verify that the output file was created and has content
                    if (File.Exists(tempOutputPath) && new FileInfo(tempOutputPath).Length > 0)
                    {
                        success = true;
                    }

                    // Clean up temporary file
                    if (File.Exists(tempOutputPath))
                    {
                        File.Delete(tempOutputPath);
                    }
                }
            }
            catch
            {
                // Swallow exceptions for individual formats; success remains false
            }

            result[format] = success;
        }

        return result;
    }

    private static ImageFormat GetImageFormat(string format)
    {
        switch (format.Trim().ToUpperInvariant())
        {
            case "JPEG":
                return ImageFormat.Jpeg;
            case "PNG":
                return ImageFormat.Png;
            case "GIF":
                return ImageFormat.Gif;
            case "BMP":
                return ImageFormat.Bmp;
            case "TIFF":
                return ImageFormat.Tiff;
            default:
                throw new ArgumentException($"Unsupported image format: {format}");
        }
    }

    private static string GetExtensionForImageFormat(ImageFormat format)
    {
        if (format == ImageFormat.Jpeg) return ".jpg";
        if (format == ImageFormat.Png) return ".png";
        if (format == ImageFormat.Gif) return ".gif";
        if (format == ImageFormat.Bmp) return ".bmp";
        if (format == ImageFormat.Tiff) return ".tiff";
        return ".img";
    }
}