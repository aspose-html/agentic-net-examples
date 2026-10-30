// Convert an EPUB file to PDF with custom page size and margins.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "result.pdf");

            Directory.CreateDirectory(outputDir);

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file (empty zip structure could be added here)
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(600)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50)));

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB converted to PDF successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}