// Batch process a directory of EPUB files, converting each to a high‑resolution PDF for archiving.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input_epubs";
            string outputDir = "output_pdfs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(2480, 3508));
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
                Console.WriteLine($"Converted '{epubPath}' to PDF at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}