// Batch convert HTML files to PDF, adding page numbers via drawing API after rendering.

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
            string inputFolder = "input";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");
                HTMLDocument document = new HTMLDocument(htmlPath);
                PdfSaveOptions options = new PdfSaveOptions();
                Size size = new Size(612, 792);
                Margin margin = new Margin(50, 50, 50, 50);
                Page page = new Page(size, margin);
                options.PageSetup.AnyPage = page;
                Converter.ConvertHTML(document, options, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}