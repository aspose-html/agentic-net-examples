// Convert an EPUB file to PDF using using statements to ensure FileStream resources are disposed.

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
            string inputPath = "sample.epub";
            string outputPath = "output.pdf";

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}