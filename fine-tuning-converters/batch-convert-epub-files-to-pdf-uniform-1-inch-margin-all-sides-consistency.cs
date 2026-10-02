// Batch convert EPUB files to PDF, applying a uniform 1‑inch margin on all sides for consistency.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB files (hardcoded for the example)
            string[] epubFiles = new string[]
            {
                "sample1.epub",
                "sample2.epub"
            };

            // Output directory
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Define PDF save options with 1-inch margins
            PdfSaveOptions pdfOptions = new PdfSaveOptions();
            Page page = new Page(
                new Size(
                    Length.FromInches(8.5),   // Width (Letter size)
                    Length.FromInches(11)     // Height (Letter size)
                ),
                new Margin(
                    Length.FromInches(1), // Left
                    Length.FromInches(1), // Top
                    Length.FromInches(1), // Right
                    Length.FromInches(1)  // Bottom
                )
            );
            pdfOptions.PageSetup.AnyPage = page;

            foreach (string epubPath in epubFiles)
            {
                // Ensure the EPUB file exists; create a minimal placeholder if not
                if (!File.Exists(epubPath))
                {
                    File.WriteAllText(epubPath, "Placeholder EPUB content");
                }

                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, outputPath);
                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}