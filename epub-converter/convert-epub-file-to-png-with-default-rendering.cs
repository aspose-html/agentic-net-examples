// Convert an EPUB file to PNG using Converter.ConvertEPUB and rely on built‑in rendering defaults.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(dataDir, "output.png");

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}