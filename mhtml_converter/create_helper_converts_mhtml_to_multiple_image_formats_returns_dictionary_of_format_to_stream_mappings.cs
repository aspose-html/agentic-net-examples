// Create a helper that converts MHTML to multiple image formats and returns a dictionary of format‑to‑stream mappings.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MhtmlToImagesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source MHTML file
                string mhtmlPath = "sample.mhtml";

                // Desired output image formats
                var formats = new List<string> { "jpeg", "png", "bmp", "gif", "tiff" };

                // Perform conversion
                var imageStreams = ConvertToImages(mhtmlPath, formats);

                // Example usage: display size of each generated stream
                foreach (var kvp in imageStreams)
                {
                    Console.WriteLine($"{kvp.Key.ToUpper()} image stream length: {kvp.Value.Length} bytes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Converts an MHTML file to multiple image formats and returns a dictionary
        /// mapping format names to MemoryStream instances containing the image data.
        /// </summary>
        /// <param name="mhtmlPath">Path to the source MHTML file.</param>
        /// <param name="formats">Collection of format names (e.g., "jpeg", "png").</param>
        /// <returns>Dictionary where key is format name and value is a MemoryStream of the image.</returns>
        public static Dictionary<string, MemoryStream> ConvertToImages(string mhtmlPath, IEnumerable<string> formats)
        {
            var result = new Dictionary<string, MemoryStream>(StringComparer.OrdinalIgnoreCase);

            foreach (var format in formats)
            {
                // Map format string to Aspose.ImageFormat enum
                ImageFormat imageFormat;
                string extension;
                switch (format.Trim().ToLower())
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
                        throw new ArgumentException($"Unsupported image format: {format}");
                }

                // Open a fresh stream for each conversion
                using (Stream inputStream = File.OpenRead(mhtmlPath))
                {
                    // Configure save options for the desired format
                    var saveOptions = new ImageSaveOptions(imageFormat);

                    // Create a temporary file path for the output image
                    string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "." + extension);

                    // Perform conversion to the temporary file
                    Converter.ConvertMHTML(inputStream, saveOptions, tempFilePath);

                    // Read the generated file into a MemoryStream
                    byte[] imageBytes = File.ReadAllBytes(tempFilePath);
                    var memoryStream = new MemoryStream(imageBytes);
                    memoryStream.Position = 0;

                    // Store the stream in the result dictionary
                    result[format] = memoryStream;

                    // Clean up the temporary file
                    File.Delete(tempFilePath);
                }
            }

            return result;
        }
    }
}