// Batch process a directory of EPUB files, converting each to a high‑resolution PDF for archiving.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "InputEpubs";
            string outputDirectory = "OutputPdfs";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            foreach (string epubPath in Directory.GetFiles(inputDirectory, "*.epub"))
            {
                try
                {
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(epubPath) + ".pdf");

                    using (FileStream stream = File.OpenRead(epubPath))
                    {
                        var options = new Aspose.Html.Saving.PdfSaveOptions();
                        // Example of setting a high‑resolution page size (A4 at 300 DPI)
                        options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                            new Aspose.Html.Drawing.Size(
                                Aspose.Html.Drawing.Length.FromPixels(2480),
                                Aspose.Html.Drawing.Length.FromPixels(3508)));

                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    }

                    Console.WriteLine($"Converted: {epubPath} -> {outputPath}");
                }
                catch (Exception exFile)
                {
                    Console.WriteLine($"Error converting file '{epubPath}': {exFile.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}