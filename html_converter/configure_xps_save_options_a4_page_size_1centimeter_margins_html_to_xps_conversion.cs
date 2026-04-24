// Configure XpsSaveOptions to use A4 page size and 1‑centimeter margins for HTML to XPS conversion.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

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

            var pageSize = new Size(Length.FromInches(8.27f), Length.FromInches(11.69f));
            var margin = new Margin(Length.FromInches(0.3937f), Length.FromInches(0.3937f), Length.FromInches(0.3937f), Length.FromInches(0.3937f));
            options.PageSetup.AnyPage = new Page(pageSize, margin);

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}