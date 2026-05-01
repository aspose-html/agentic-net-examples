// Override default DPI to 450 when rendering large HTML reports to PNG for detailed analysis.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "report.html";
            string outputPath = "report.png";

            string htmlContent = System.IO.File.ReadAllText(htmlPath);
            string baseUri = new Uri(System.IO.Path.GetFullPath(htmlPath)).AbsoluteUri;

            var options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 450;
            options.VerticalResolution = 450;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}