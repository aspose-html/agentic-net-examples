// Write a wrapper method that selects appropriate ImageSaveOptions based on the desired output image format.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

namespace ImageSaveOptionsWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Example usage: convert HTML to PNG image
                string htmlPath = "sample.html";
                string outputPath = "output.png";
                string desiredFormat = "png";

                ImageSaveOptions options = GetImageSaveOptions(desiredFormat);
                Converter.ConvertHTML(htmlPath, options, outputPath);
                Console.WriteLine($"Conversion completed. Image saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns an ImageSaveOptions instance configured for the specified image format.
        /// Supported formats: png, jpeg, gif, bmp, tiff (case-insensitive).
        /// </summary>
        /// <param name="format">Desired image format as a string.</param>
        /// <returns>Configured ImageSaveOptions.</returns>
        static ImageSaveOptions GetImageSaveOptions(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Format must be a non-empty string.", nameof(format));

            // Normalize format string
            string fmt = format.Trim().ToLowerInvariant();

            // Select appropriate ImageFormat and create ImageSaveOptions
            switch (fmt)
            {
                case "png":
                    return new ImageSaveOptions(ImageFormat.Png);
                case "jpeg":
                case "jpg":
                    return new ImageSaveOptions(ImageFormat.Jpeg);
                case "gif":
                    return new ImageSaveOptions(ImageFormat.Gif);
                case "bmp":
                    return new ImageSaveOptions(ImageFormat.Bmp);
                case "tiff":
                case "tif":
                    return new ImageSaveOptions(ImageFormat.Tiff);
                default:
                    throw new NotSupportedException($"Image format '{format}' is not supported.");
            }
        }
    }
}