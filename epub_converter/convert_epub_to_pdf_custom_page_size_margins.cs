// Convert an EPUB file to PDF with custom page size and margins.

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
            using (FileStream stream = File.OpenRead("input.epub"))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page()
                {
                    Size = new Size(Length.FromPixels(1000), Length.FromPixels(1000))
                };
                Converter.ConvertEPUB(stream, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}