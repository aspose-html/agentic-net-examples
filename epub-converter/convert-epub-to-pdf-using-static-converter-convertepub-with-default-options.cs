// Convert an EPUB file to PDF using the static Converter.ConvertEPUB method with default options.

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

            // Ensure the input file exists (create an empty placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                using (var placeholder = File.Create(inputPath))
                {
                    // No content needed for placeholder
                }
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}