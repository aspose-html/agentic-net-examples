// Validate that the output PNG file exists after conversion and throw an error if missing.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            string epubFile = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.png");

            Directory.CreateDirectory(outputDir);
            using (FileStream stream = File.OpenRead(epubFile))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            if (!File.Exists(outputPath))
                throw new FileNotFoundException("PNG file was not created.", outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}