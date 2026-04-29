// Configure PdfSaveOptions to set a custom document title metadata based on the source MHTML filename.

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
            string sourcePath = "sample.mhtml";
            string outputPath = "output.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.DocumentInfo.Title = Path.GetFileNameWithoutExtension(sourcePath);

            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}