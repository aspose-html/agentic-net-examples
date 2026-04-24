// Convert an EPUB file to PDF ensuring the output directory exists before writing the file.

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
            string inputPath = "input.epub";
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "output.pdf");

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            PdfSaveOptions options = new PdfSaveOptions();
            Converter.ConvertEPUB(inputPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}