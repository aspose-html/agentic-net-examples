// Convert an EPUB file to DOCX and save the output to a user‑specified directory.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Expect two arguments: path to the EPUB file and the output directory
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <epubPath> <outputDirectory>");
                return;
            }

            // Source EPUB file path
            string sourcePath = args[0];

            // Ensure the output directory exists
            string outputDirectory = args[1];
            Directory.CreateDirectory(outputDirectory);

            // Build the full output DOCX file path
            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(sourcePath) + ".docx");

            // Create default DOCX save options
            DocSaveOptions options = new DocSaveOptions();

            // Perform the conversion from EPUB to DOCX
            Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}