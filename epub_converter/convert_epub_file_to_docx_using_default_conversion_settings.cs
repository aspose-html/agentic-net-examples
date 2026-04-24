// Convert an EPUB file to DOCX using Converter.ConvertEPUB with default conversion settings.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.epub";
            string outputPath = "output.docx";

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                DocSaveOptions options = new DocSaveOptions();
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}