// Render an EPUB to PDF with custom top margin of 25 points to accommodate header space.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var renderer = new Aspose.Html.Rendering.EpubRenderer();
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            var anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842));
            anyPage.Margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromPoints(0),
                Aspose.Html.Drawing.Length.FromPoints(25),
                Aspose.Html.Drawing.Length.FromPoints(0),
                Aspose.Html.Drawing.Length.FromPoints(0));

            options.PageSetup.AnyPage = anyPage;

            using (var stream = File.OpenRead("input.epub"))
            {
                var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf");
                renderer.Render(device, stream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}