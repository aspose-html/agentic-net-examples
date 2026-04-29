// Configure DocSaveOptions to enforce OpenXML strict compliance when generating DOCX from MHTML for enterprise standards.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";

            // Desired output DOCX file path
            string outputPath = "output.docx";

            // Open the MHTML file as a readable stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create DocSaveOptions instance (default settings)
                DocSaveOptions saveOptions = new DocSaveOptions();

                // NOTE: Aspose.HTML DocSaveOptions does not expose an OpenXML compliance property.
                // The conversion proceeds with default options which are suitable for most scenarios.

                // Convert MHTML to DOCX using the Aspose.HTML converter
                Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}