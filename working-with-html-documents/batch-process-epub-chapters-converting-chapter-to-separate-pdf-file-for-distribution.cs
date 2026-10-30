// Batch process EPUB chapters, converting each chapter to a separate PDF file for distribution.

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
            string inputDir = "input_epubs";
            string outputDir = "output_pdfs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a dummy EPUB file if none exist (for demonstration purposes)
            if (Directory.GetFiles(inputDir, "*.epub").Length == 0)
            {
                string dummyEpubPath = Path.Combine(inputDir, "chapter1.epub");
                using (FileStream fs = new FileStream(dummyEpubPath, FileMode.Create, FileAccess.Write))
                {
                    // Minimal placeholder content; a real EPUB would be required for actual conversion
                }
            }

            foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                string pdfPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                using (FileStream stream = new FileStream(epubPath, FileMode.Open, FileAccess.Read))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, pdfPath);
                }

                Console.WriteLine($"Converted '{epubPath}' to '{pdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}