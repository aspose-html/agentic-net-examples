// Convert an EPUB file to XPS ensuring the output directory exists before writing the file.

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
            // Path to the source EPUB file
            string inputPath = "input.epub";

            // Ensure the output directory exists
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            // Path for the resulting XPS file
            string outputPath = Path.Combine(outputDirectory, "output.xps");

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Initialize XPS save options with default settings
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion from EPUB to XPS
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}