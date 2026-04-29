// Generate a DOCX document from an SVG image using the Converter with appropriate save options.

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
            // Define input SVG file path and output DOCX file path
            string dataDir = "Data";
            string outputDir = "Output";
            string sourcePath = Path.Combine(dataDir, "image.svg");
            string outputPath = Path.Combine(outputDir, "result.docx");

            // Create default DOCX save options
            DocSaveOptions options = new DocSaveOptions();

            // Convert SVG to DOCX
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}