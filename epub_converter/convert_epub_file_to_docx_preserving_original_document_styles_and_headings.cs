// Convert an EPUB file to DOCX while preserving original document styles and headings.

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
            string sourcePath = "input.epub";
            string outputPath = "output.docx";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                DocSaveOptions options = new DocSaveOptions();
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}