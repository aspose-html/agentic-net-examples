// Batch convert EPUB files to PDF, applying a uniform 1‑inch margin on all sides for consistency.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input";
            string outputDir = "output";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
            {
                using (Stream stream = File.OpenRead(epubPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.PageSetup.AnyPage = new Page();
                    options.PageSetup.AnyPage.Margin = new Margin(
                        Length.FromInches(1),
                        Length.FromInches(1),
                        Length.FromInches(1),
                        Length.FromInches(1));

                    string outputPath = Path.Combine(outputDir,
                        Path.GetFileNameWithoutExtension(epubPath) + ".pdf");

                    Converter.ConvertEPUB(stream, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}