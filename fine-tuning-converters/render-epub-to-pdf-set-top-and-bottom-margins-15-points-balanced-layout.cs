// Render an EPUB to PDF and set both top and bottom margins to 15 points for balanced layout.

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
            string inputPath = "sample.epub";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();

                Page page = new Page(
                    new Size(595, 842),
                    new Margin(0, 15, 0, 15));

                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB converted to PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}