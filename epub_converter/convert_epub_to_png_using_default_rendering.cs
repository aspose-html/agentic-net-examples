// Convert an EPUB file to PNG using Converter.ConvertEPUB and rely on built‑in rendering defaults.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace EpubToPngExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataDir = "Data";
                string outputDir = "Output";
                string epubPath = Path.Combine(dataDir, "sample.epub");
                string pngPath = Path.Combine(outputDir, "sample.png");

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    Converter.ConvertEPUB(stream, options, pngPath);
                }

                Console.WriteLine("EPUB converted to PNG successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}