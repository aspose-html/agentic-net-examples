// Convert an EPUB file to DOCX while preserving original document styles and headings.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input EPUB file path and output DOCX file path
            string sourcePath = "sample.epub";
            string outputPath = "sample.docx";

            // Ensure the input file exists (optional check)
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Input file not found: {sourcePath}");
                return;
            }

            // Create DOCX save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Perform conversion from EPUB to DOCX
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("EPUB successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}