// Convert a DRM‑free EPUB to PNG while handling potential encryption exceptions during the conversion process.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace AsposeHtmlEpubToPngExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataDir = "Data";
                string outputDir = "Output";
                Directory.CreateDirectory(dataDir);
                Directory.CreateDirectory(outputDir);

                string epubPath = Path.Combine(dataDir, "sample.epub");
                string outputPath = Path.Combine(outputDir, "output.png");

                if (!File.Exists(epubPath))
                {
                    // Create a placeholder EPUB file (actual conversion will require a valid EPUB)
                    using (FileStream placeholder = File.Create(epubPath)) { }
                }

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during EPUB to PNG conversion: " + ex.Message);
            }
        }
    }
}