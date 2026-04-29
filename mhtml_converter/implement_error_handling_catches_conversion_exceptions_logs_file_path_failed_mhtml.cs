// Implement error handling that catches conversion exceptions and logs source file path for failed MHTML.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        // Path to the source MHTML file
        string sourcePath = "input.mhtml";
        // Desired output DOCX file path
        string outputPath = "output.docx";

        try
        {
            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Configure default DOCX saving options
                DocSaveOptions options = new DocSaveOptions();
                // Perform the conversion
                Converter.ConvertMHTML(stream, options, outputPath);
            }
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            // Log the source file path and error details for failed conversion
            Console.WriteLine($"Conversion failed for file: {sourcePath}");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}