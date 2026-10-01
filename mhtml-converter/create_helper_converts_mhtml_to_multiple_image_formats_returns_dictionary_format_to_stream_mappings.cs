// Create a helper that converts MHTML to multiple image formats and returns a dictionary of format‑to‑stream mappings.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal sample MHTML file (simple HTML content for demonstration)
            string mhtmlPath = Path.Combine(Path.GetTempPath(), "sample.mhtml");
            File.WriteAllText(mhtmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Desired image formats
            var formats = new List<string> { "png", "jpeg", "bmp", "gif", "tiff" };

            // Convert MHTML to images
            var images = ConvertToImages(mhtmlPath, formats);

            // Save the resulting images to disk for verification
            foreach (var kvp in images)
            {
                string outputFile = Path.Combine(Path.GetTempPath(), $"output_{kvp.Key}.{kvp.Key}");
                using (var fileStream = File.Create(outputFile))
                {
                    kvp.Value.CopyTo(fileStream);
                }
                Console.WriteLine($"Image saved: {outputFile}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, MemoryStream> ConvertToImages(string mhtmlPath, IEnumerable<string> formats)
    {
        var result = new Dictionary<string, MemoryStream>(StringComparer.OrdinalIgnoreCase);

        foreach (var format in formats)
        {
            // Map format string to Aspose.Html.Rendering.Image.ImageFormat and file extension
            Aspose.Html.Rendering.Image.ImageFormat imageFormat;
            string extension;

            switch (format.Trim().ToLowerInvariant())
            {
                case "jpeg":
                case "jpg":
                    imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
                    extension = "jpg";
                    break;
                case "png":
                    imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Png;
                    extension = "png";
                    break;
                case "bmp":
                    imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Bmp;
                    extension = "bmp";
                    break;
                case "gif":
                    imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Gif;
                    extension = "gif";
                    break;
                case "tiff":
                case "tif":
                    imageFormat = Aspose.Html.Rendering.Image.ImageFormat.Tiff;
                    extension = "tiff";
                    break;
                default:
                    throw new ArgumentException($"Unsupported image format: {format}");
            }

            // Open a fresh input stream for each conversion
            using (Stream inputStream = File.OpenRead(mhtmlPath))
            {
                // Configure save options
                var options = new Aspose.Html.Saving.ImageSaveOptions(imageFormat);

                // Create a temporary output file path
                string tempOutputPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.{extension}");

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempOutputPath);

                // Read the generated image into a MemoryStream
                byte[] imageBytes = File.ReadAllBytes(tempOutputPath);
                var memoryStream = new MemoryStream(imageBytes);
                memoryStream.Position = 0;

                // Store in result dictionary
                result[extension] = memoryStream;

                // Clean up temporary file
                File.Delete(tempOutputPath);
            }
        }

        return result;
    }
}