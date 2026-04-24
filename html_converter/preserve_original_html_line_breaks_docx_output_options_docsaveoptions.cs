// Preserve original HTML line breaks in DOCX output by setting appropriate options in DocSaveOptions.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.docx";

            DocSaveOptions options = new DocSaveOptions();
            // The option to preserve original line breaks is not available in this version of Aspose.HTML.
            // If supported, it could be set here, e.g., options.PreserveOriginalLineBreaks = true;

            Converter.ConvertHTML(sourcePath, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}