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
            string outputPath = Path.Combine("Output", "result.pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(1000)),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50),
                        Aspose.Html.Drawing.Length.FromPixels(50)));

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}