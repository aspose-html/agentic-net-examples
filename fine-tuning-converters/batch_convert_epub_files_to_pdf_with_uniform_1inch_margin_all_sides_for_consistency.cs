// Batch convert EPUB files to PDF, applying a uniform 1‑inch margin on all sides for consistency.

using System;
using System.IO;

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

            // Create a dummy EPUB file if none exist (for demonstration purposes)
            if (Directory.GetFiles(inputDir, "*.epub").Length == 0)
            {
                string dummyPath = Path.Combine(inputDir, "sample.epub");
                File.WriteAllBytes(dummyPath, new byte[0]);
            }

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromInches(8.5),
                            Aspose.Html.Drawing.Length.FromInches(11)),
                        new Aspose.Html.Drawing.Margin(
                            Aspose.Html.Drawing.Length.FromInches(1),
                            Aspose.Html.Drawing.Length.FromInches(1),
                            Aspose.Html.Drawing.Length.FromInches(1),
                            Aspose.Html.Drawing.Length.FromInches(1)));

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}