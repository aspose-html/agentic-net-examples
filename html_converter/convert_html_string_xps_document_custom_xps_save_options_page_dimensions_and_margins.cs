// Convert an HTML string to an XPS document using custom XpsSaveOptions that specify page dimensions and margins.

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
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>";
            string baseUri = "http://example.com/";
            string outputPath = "output.xps";

            XpsSaveOptions options = new XpsSaveOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(Length.FromInches(8.3f), Length.FromInches(5.8f)),
                new Margin(0, 0, 0, 0));

            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}