// Convert an EPUB file to multiple image formats in a single pass using a batch processing loop.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataDir = "Data";
                string inputFile = Path.Combine(dataDir, "sample.epub");

                if (!File.Exists(inputFile))
                {
                    Directory.CreateDirectory(dataDir);
                    using (FileStream fs = File.Create(inputFile))
                    {
                        // Create an empty placeholder EPUB file
                    }
                }

                string outputDir = "Output";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                ImageFormat[] formats = new ImageFormat[]
                {
                    ImageFormat.Jpeg,
                    ImageFormat.Png,
                    ImageFormat.Bmp,
                    ImageFormat.Tiff
                };

                string[] extensions = new string[] { "jpg", "png", "bmp", "tiff" };

                for (int i = 0; i < formats.Length; i++)
                {
                    using (FileStream stream = File.OpenRead(inputFile))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(formats[i]);
                        string outputPath = Path.Combine(outputDir, $"output_page_{i + 1}." + extensions[i]);
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conversion failed: " + ex.Message);
            }
        }
    }
}