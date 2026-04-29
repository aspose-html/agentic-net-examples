// Load an SVG from a URL and convert it to DOCX with custom DocSaveOptions.

using System;
using System.Net.Http;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string svgUrl = "https://example.com/image.svg";
            string svgContent;
            using (HttpClient client = new HttpClient())
            {
                svgContent = client.GetStringAsync(svgUrl).Result;
            }

            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Size(500, 500), new Margin(30, 10, 10, 10));

            string outputPath = "output.docx";

            Converter.ConvertSVG(svgContent, svgUrl, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}