// Convert an EPUB file to multiple image formats in a single pass using a batch processing loop.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace EpubBatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataDir = "Data";
                string outputDir = "Output";
                string epubFileName = "sample.epub";
                string epubPath = Path.Combine(dataDir, epubFileName);
                string[] formats = { "Jpeg", "Png", "Bmp", "Tiff" };
                foreach (var fmt in formats)
                {
                    using (FileStream stream = File.OpenRead(epubPath))
                    {
                        ImageSaveOptions options;
                        switch (fmt)
                        {
                            case "Jpeg":
                                options = new ImageSaveOptions(ImageFormat.Jpeg);
                                break;
                            case "Png":
                                options = new ImageSaveOptions(ImageFormat.Png);
                                break;
                            case "Bmp":
                                options = new ImageSaveOptions(ImageFormat.Bmp);
                                break;
                            case "Tiff":
                                options = new ImageSaveOptions(ImageFormat.Tiff);
                                break;
                            default:
                                continue;
                        }
                        string outputFileName = Path.GetFileNameWithoutExtension(epubFileName) + "_" + fmt.ToLower() + "." + fmt.ToLower();
                        string outputPath = Path.Combine(outputDir, outputFileName);
                        Converter.ConvertEPUB(stream, options, outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}