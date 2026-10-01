// Validate that the output PNG file exists after conversion and throw an error if missing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Sample EPUB file path
            string epubPath = Path.Combine(dataDir, "sample.epub");

            // Create a minimal placeholder EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                // An empty file is used as a placeholder; replace with a valid EPUB for real conversion
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Output PNG path
            string outputPath = Path.Combine(outputDir, "output.png");

            // Perform conversion
            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            // Validate that the output file exists
            if (!File.Exists(outputPath))
            {
                throw new FileNotFoundException("The output PNG file was not created.", outputPath);
            }

            Console.WriteLine("Conversion succeeded. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}