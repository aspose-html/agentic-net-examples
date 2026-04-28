// Set CssOptions.MediaType to Screen when converting HTML to DOCX to retain on‑screen styling.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.docx";

            DocSaveOptions options = new DocSaveOptions();
            options.Css.MediaType = MediaType.Screen;

            Converter.ConvertHTML(inputPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}