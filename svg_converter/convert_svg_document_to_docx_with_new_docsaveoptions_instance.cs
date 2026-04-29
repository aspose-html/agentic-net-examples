// Convert an SVG document to DOCX by providing a new DocSaveOptions instance.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Create default DOCX save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Convert the SVG file to a DOCX document
            Converter.ConvertSVG("input.svg", options, "output.docx");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}