// Implement a method that returns a dictionary mapping each supported output format to its conversion success flag.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file
            string mhtmlPath = Path.Combine(Path.GetTempPath(), "sample.mhtml");
            File.WriteAllText(mhtmlPath, "<html><body><p>Sample MHTML content</p></body></html>");

            // Define desired output formats
            var formats = new List<string> { "JPEG", "PNG", "BMP", "GIF", "TIFF" };

            // Perform conversions
            var results = ConvertMhtmlToFormats(mhtmlPath, formats);

            // Print results
            foreach (var kvp in results)
            {
                Console.WriteLine($"{kvp.Key}: {(kvp.Value ? "Success" : "Failed")}");
            }

            // Cleanup sample MHTML file
            if (File.Exists(mhtmlPath))
                File.Delete(mhtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, bool> ConvertMhtmlToFormats(string mhtmlPath, IEnumerable<string> formats)
    {
        var result = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

        foreach (var format in formats)
        {
            bool success = false;
            try
            {
                // Map format string to ImageFormat enum
                Aspose.Html.Rendering.Image.ImageFormat imageFormat = GetImageFormat(format);
                string extension = GetExtension(format);

                // Prepare temporary output file path
                string outputPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + extension);

                // Create ImageSaveOptions with the selected format
                var options = new Aspose.Html.Saving.ImageSaveOptions(imageFormat);

                // Open a fresh input stream for each conversion
                using (FileStream inputStream = File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
                }

                // Verify that the output file was created
                if (File.Exists(outputPath))
                {
                    // Optionally read the file into a MemoryStream (not required for the flag)
                    using (var ms = new MemoryStream(File.ReadAllBytes(outputPath)))
                    {
                        ms.Position = 0;
                    }
                    success = true;
                    // Cleanup the generated image file
                    File.Delete(outputPath);
                }
            }
            catch
            {
                success = false;
            }

            result[format] = success;
        }

        return result;
    }

    static Aspose.Html.Rendering.Image.ImageFormat GetImageFormat(string format)
    {
        switch (format.Trim().ToUpperInvariant())
        {
            case "JPEG":
                return Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
            case "PNG":
                return Aspose.Html.Rendering.Image.ImageFormat.Png;
            case "BMP":
                return Aspose.Html.Rendering.Image.ImageFormat.Bmp;
            case "GIF":
                return Aspose.Html.Rendering.Image.ImageFormat.Gif;
            case "TIFF":
                return Aspose.Html.Rendering.Image.ImageFormat.Tiff;
            default:
                throw new ArgumentException($"Unsupported image format: {format}");
        }
    }

    static string GetExtension(string format)
    {
        switch (format.Trim().ToUpperInvariant())
        {
            case "JPEG":
                return ".jpg";
            case "PNG":
                return ".png";
            case "BMP":
                return ".bmp";
            case "GIF":
                return ".gif";
            case "TIFF":
                return ".tiff";
            default:
                return ".img";
        }
    }
}