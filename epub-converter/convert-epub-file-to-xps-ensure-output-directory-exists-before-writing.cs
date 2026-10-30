// Convert an EPUB file to XPS ensuring the output directory exists before writing the file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Prepare sample EPUB file path
            string sourcePath = Path.Combine(inputDirectory, "sample.epub");

            // Create a minimal sample EPUB file if it does not exist
            if (!File.Exists(sourcePath))
            {
                // This is not a valid EPUB but serves as a placeholder for the example
                File.WriteAllText(sourcePath, "Sample EPUB content");
            }

            // Prepare output XPS file path
            string outputPath = Path.Combine(outputDirectory, "sample.xps");

            // Ensure the output directory exists (already created above)
            // Open the EPUB file stream
            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Create XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Convert EPUB to XPS
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"EPUB file '{sourcePath}' has been successfully converted to XPS at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}