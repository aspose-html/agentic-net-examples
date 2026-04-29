// Set custom margins and page size in PdfSaveOptions while converting MHTML to PDF for printing.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            Stream stream = File.OpenRead(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();

            Size pageSize = new Size(595, 842); // Width and height in points (A4 size)
            Margin pageMargin = new Margin(20, 20, 20, 20); // Top, Right, Bottom, Left margins
            Page page = new Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            Converter.ConvertMHTML(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}