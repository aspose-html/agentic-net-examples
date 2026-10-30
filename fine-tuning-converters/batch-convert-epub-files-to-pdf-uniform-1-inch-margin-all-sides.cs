// Batch convert EPUB files to PDF, applying a uniform 1‑inch margin on all sides for consistency.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputPdfs";

            System.IO.Directory.CreateDirectory(inputDir);
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a minimal sample EPUB file if none exist (empty file for demonstration)
            string sampleEpubPath = System.IO.Path.Combine(inputDir, "sample.epub");
            if (!System.IO.File.Exists(sampleEpubPath))
            {
                System.IO.File.WriteAllBytes(sampleEpubPath, new byte[0]);
            }

            foreach (string epubFile in System.IO.Directory.GetFiles(inputDir, "*.epub"))
            {
                using (System.IO.Stream stream = System.IO.File.OpenRead(epubFile))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();

                    // Define page size (8.5"x11" at 72 DPI = 612x792 points) and 1‑inch margins (72 points)
                    var page = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(612, 792),
                        new Aspose.Html.Drawing.Margin(72, 72, 72, 72));

                    options.PageSetup.AnyPage = page;

                    string outputPath = System.IO.Path.Combine(
                        outputDir,
                        System.IO.Path.GetFileNameWithoutExtension(epubFile) + ".pdf");

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            }

            Console.WriteLine("Batch EPUB to PDF conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}