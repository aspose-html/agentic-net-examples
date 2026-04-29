// Set DOCX page setup to track revisions using DocSaveOptions.TrackRevisions for change tracking.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create DOCX save options
            DocSaveOptions options = new DocSaveOptions();

            // The TrackRevisions property is not available in Aspose.HTML's DocSaveOptions.
            // If it were supported, it could be set here, e.g., options.TrackRevisions = true;

            // Example conversion: HTML to DOCX using the options
            string sourcePath = "input.html";
            string outputPath = "output.docx";
            Converter.ConvertHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}