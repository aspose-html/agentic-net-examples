// Render HTML to XPS with custom left margin of 10 millimeters by adjusting XpsRenderingOptions.MarginLeft.

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
            string htmlPath = "input.html";
            string outputPath = "output.xps";

            HTMLDocument document = new HTMLDocument(htmlPath);
            XpsSaveOptions options = new XpsSaveOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(Length.FromInches(8), Length.FromInches(11)),
                new Margin(10, 0, 0, 0));

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}