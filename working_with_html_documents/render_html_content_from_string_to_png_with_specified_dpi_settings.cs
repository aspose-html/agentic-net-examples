// Render HTML content loaded from a string directly to PNG with specified DPI settings.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = new Uri(System.IO.Path.GetFullPath(".")).AbsoluteUri;
            string outputPath = "output.png";

            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}