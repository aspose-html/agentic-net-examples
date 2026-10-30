// Convert an EPUB file to PDF by reading the source via FileStream with read‑only access.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.epub");
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

            using (System.IO.Stream epubStream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB converted to PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}