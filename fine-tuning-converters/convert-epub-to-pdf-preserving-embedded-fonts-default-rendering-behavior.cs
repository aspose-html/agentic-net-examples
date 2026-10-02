// Convert an EPUB document to PDF while preserving embedded fonts through default rendering behavior.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDirectory = "output";
            string outputPath = System.IO.Path.Combine(outputDirectory, "result.pdf");

            // Ensure the output directory exists
            System.IO.Directory.CreateDirectory(outputDirectory);

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}