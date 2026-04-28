// Apply a uniform 1‑centimeter right margin to all DOCX outputs by configuring DocRenderingOptions globally.

using System;
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
            string sourceHtml = "input.html";
            string outputDocx = "output.docx";

            HTMLDocument document = new HTMLDocument(sourceHtml);
            DocSaveOptions options = new DocSaveOptions();

            Size size = new Size(595, 842); // A4 size in points
            Margin margin = new Margin(0, 28, 0, 0); // Right margin = 1 cm (≈28 points)
            Page page = new Page(size, margin);
            options.PageSetup.AnyPage = page;

            Converter.ConvertHTML(document, options, outputDocx);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}