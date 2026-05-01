// Render an MHTML email archive to PDF while preserving embedded images and styles.

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
            string inputPath = Path.Combine("Input", "emailArchive.mhtml");
            string outputPath = Path.Combine("Output", "emailArchive.pdf");

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}