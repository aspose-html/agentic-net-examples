// Convert all EPUB files in a directory to PDF using Parallel.ForEach with default PdfSaveOptions.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputPdfs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub", SearchOption.TopDirectoryOnly);

            Parallel.ForEach(epubFiles, epubPath =>
            {
                string fileName = Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = Path.Combine(outputDir, fileName + ".pdf");

                using (Stream stream = File.OpenRead(epubPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            });

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}