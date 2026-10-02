// Convert an EPUB file to PDF specifying the output path using Path.Combine for platform‑independent paths.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (adjust as needed)
            string sourcePath = "sample.epub";

            // Ensure the output directory exists
            string outputDirectory = "output";
            System.IO.Directory.CreateDirectory(outputDirectory);

            // Combine output directory with file name in a platform‑independent way
            string outputPath = System.IO.Path.Combine(outputDirectory, "output.pdf");

            // Create PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("EPUB successfully converted to PDF:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}