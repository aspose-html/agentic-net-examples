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
            // Prepare a minimal MHTML file
            string mhtmlPath = Path.Combine(Path.GetTempPath(), "sample.mhtml");
            string mhtmlContent = "From: <Saved by WebKit>\r\n" +
                                  "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                  "------=_NextPart_000_0000\r\n" +
                                  "Content-Type: text/html; charset=\"utf-8\"\r\n\r\n" +
                                  "<html><body><h1>Hello MHTML</h1></body></html>\r\n" +
                                  "------=_NextPart_000_0000--";
            File.WriteAllText(mhtmlPath, mhtmlContent);

            // Convert to images
            var formats = new List<string> { "jpeg", "png", "bmp", "gif", "tiff" };
            var images = ConvertToImages(mhtmlPath, formats);

            // Output result info
            foreach (var kvp in images)
            {
                Console.WriteLine($"Format: {kvp.Key}, Size: {kvp.Value.Length} bytes");
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

        foreach (var format in formats)
        {
            ImageFormat imageFormat;
            string extension;

            switch (format.ToLowerInvariant())
            {
                case "jpeg":
                case "jpg":
                    imageFormat = ImageFormat.Jpeg;
                    extension = "jpg";
                    break;
                case "png":
                    imageFormat = ImageFormat.Png;
                    extension = "png";
                    break;
                case "bmp":
                    imageFormat = ImageFormat.Bmp;
                    extension = "bmp";
                    break;
                case "gif":
                    imageFormat = ImageFormat.Gif;
                    extension = "gif";
                    break;
                case "tiff":
                case "tif":
                    imageFormat = ImageFormat.Tiff;
                    extension = "tiff";
                    break;
                default:
                    throw new ArgumentException($"Unsupported format: {format}");
            }

            // Open fresh input stream for each conversion
            using (var inputStream = File.OpenRead(mhtmlPath))
            {
                var options = new ImageSaveOptions(imageFormat);

                // Create temporary output file path
                string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "." + extension);

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempFile);

                // Read output bytes and wrap in MemoryStream
                byte[] bytes = File.ReadAllBytes(tempFile);
                var memoryStream = new MemoryStream(bytes);
                memoryStream.Position = 0;

                result[format] = memoryStream;

                // Cleanup temporary file
                File.Delete(tempFile);
            }
        }

        return result;
    }
}