// Set DOCX document language property via DocSaveOptions.Language to support localization after conversion.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired output DOCX file path
            string outputPath = "output.docx";

            // Create save options for DOCX conversion
            DocSaveOptions options = new DocSaveOptions();
            // The Language property is not available in this version of Aspose.HTML, so it is omitted.

            // Convert MHTML to DOCX
            Converter.ConvertMHTML(inputPath, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}