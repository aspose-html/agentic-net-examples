// Resize embedded images in HTML before PDF conversion to reduce final PDF size while preserving quality.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            var images = document.QuerySelectorAll("img");
            foreach (var node in images)
            {
                var element = (Aspose.Html.Dom.Element)node;
                element.SetAttribute("style", "max-width:800px; height:auto;");
            }

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 80;

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(600, 300),
                new Aspose.Html.Drawing.Margin(20, 10, 10, 10));

            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}