// Define custom page size of A4 in ImageSaveOptions before converting HTML to PDF for standard documents.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.pdf";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, PDF!</h1></body></html>");
            }

            HTMLDocument document = new HTMLDocument(htmlPath);
            PdfSaveOptions options = new PdfSaveOptions();

            Length width = Length.FromInches(8.27f);
            Length height = Length.FromInches(11.69f);
            Size pageSize = new Size(width, height);
            Margin margin = new Margin(0, 0, 0, 0);
            Page page = new Page(pageSize, margin);

            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}