// Export an EPUB chapter to PDF, preserving embedded images and text formatting.

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
            string inputPath = "input.epub";
            string outputPath = "output.pdf";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}