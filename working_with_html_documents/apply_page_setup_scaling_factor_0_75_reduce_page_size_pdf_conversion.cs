// Apply PageSetup scaling factor of 0.75 to reduce page size during PDF conversion.

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
            var document = new HTMLDocument("input.html");
            var options = new PdfSaveOptions();
            var scaledWidth = (int)(595 * 0.75);
            var scaledHeight = (int)(842 * 0.75);
            options.PageSetup.AnyPage = new Page(new Size(Length.FromPixels(scaledWidth), Length.FromPixels(scaledHeight)));
            Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}