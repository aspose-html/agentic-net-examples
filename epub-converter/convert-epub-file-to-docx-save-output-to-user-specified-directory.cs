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
            string sourcePath = "sample.epub";
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "result.docx");

            DocSaveOptions options = new DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}